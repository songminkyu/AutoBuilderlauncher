
using AutoBuilderlauncher.Model;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Text;

namespace AutoBuilderlauncher.Service
{
   
    public class HttpProvider
    {
        private static readonly AsyncLock mutex = new AsyncLock();
        public HttpProvider()
        {          
        }
        
        private async Task<HttpResultData<TContext>> HttpSendJsonStreamMessage<TContext>(string PostMsg, string url, string encode, 
                                                                                         string Method = WebRequestMethods.Http.Post) 
            where TContext : class, new()
        {
            string ResponseGetString = string.Empty;
            int ErrorCode = 0;
            HttpResultData<TContext> Result = new HttpResultData<TContext>();

            if (url.IndexOf("https://") >= 0)
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
            }

            try
            {
                HttpWebRequest HttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebRequest.Method = Method;
                HttpWebRequest.Timeout = 600000; //원격서버 빌드가 오래걸리므로 최대 10분까지 기다림
                Stream RequestStream = null;
                byte[] SendData = null;

                if (PostMsg != null)
                {                                       
                    SendData                     = UTF8Encoding.UTF8.GetBytes(PostMsg);
                    HttpWebRequest.ContentType   = $"application/json; charset={encode}";
                    HttpWebRequest.ContentLength = SendData.Length;
                    RequestStream                = await HttpWebRequest.GetRequestStreamAsync();
                    await RequestStream.WriteAsync(SendData, 0, SendData.Length);
                }
                else
                {
                    HttpWebRequest.ContentLength = 0;
                    RequestStream                = await HttpWebRequest.GetRequestStreamAsync();
                }
                await RequestStream.FlushAsync();
                RequestStream.Close();

                HttpWebResponse httpWebResponse = (HttpWebResponse)await HttpWebRequest.GetResponseAsync();
                StreamReader streamReader       = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding(encode));
                ResponseGetString               = await streamReader.ReadToEndAsync();
                streamReader.Close();
                httpWebResponse.Close();

                Result.ErrorCode                = ErrorCode;
                Result.ResponseData             = ResponseGetString;

            }
            catch (WebException ex)
            {
                if (ex.Response is HttpWebResponse)
                {
                    Result.ErrorCode    = (int)((HttpWebResponse)ex.Response).StatusCode;
                    Result.ResponseData = ex.Message;
                }
                else
                {
                    Result.ErrorCode    = -1;
                    Result.ResponseData = ex.Message;
                }              
            }
        
            return Result;
        }   
        public async Task<HttpResultData<TContext>> HttpSendMessage<TContext>(TContext SendMessage, string url, string encode, 
                                                                              string Method = WebRequestMethods.Http.Post)
            where TContext : class, new()
        {            
            HttpResultData<TContext> Result = new HttpResultData<TContext>();

            using (await mutex.LockAsync())
            {              
                try
                {
                    string PostMsg = string.Empty;

                    ConverterJson json = new ConverterJson();
                    PostMsg = json.SerializeToJson<TContext>(SendMessage);
                    Result = await HttpSendJsonStreamMessage<TContext>(PostMsg, url, encode, Method);
                }
                catch (Exception ex)
                {
                    Result.ErrorCode = -1;
                    Result.ResponseData = ex.Message;                    
                }               
            }
            return Result;
        }

        private async Task<HttpResultData<TContext>> HttpGetReponseMessage<TContext>(string Url)
            where TContext : class, new()
        {
            string ResponseGetString = string.Empty;
            int ErrorCode = 0;
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(Url);

            HttpResultData<TContext> Result = new HttpResultData<TContext>();

            try
            {
                Request.Method = WebRequestMethods.Http.Get;
                Request.ContentType = "application/json;charset=utf-8";
                HttpWebResponse response = (HttpWebResponse)await Request.GetResponseAsync();
                Stream RespPostStream = response.GetResponseStream();
                StreamReader ReaderPost = new StreamReader(RespPostStream, Encoding.UTF8);
                ResponseGetString = await ReaderPost.ReadToEndAsync();

                Result.ErrorCode = ErrorCode;
                Result.ResponseData = ResponseGetString;
            }
            catch (WebException ex)
            {
                if (ex.Response is HttpWebResponse)
                {
                    Result.ErrorCode = (int)((HttpWebResponse)ex.Response).StatusCode;
                    Result.ResponseData = ex.Message;
                }
                else
                {
                    Result.ErrorCode = -1;
                    Result.ResponseData = ex.Message;
                }
            }

            return Result;
        }
        public async Task<HttpResultData<TContext>> HTTPGetMessage<TContext>(string Url) 
            where TContext : class, new()
        {
            using (await mutex.LockAsync())
            {
                HttpResultData<TContext> Result = new HttpResultData<TContext>();

                try
                {
                    Result = await HttpGetReponseMessage<TContext>(Url);

                    if (Result.ErrorCode == 0)
                    {
                        ConverterJson json = new ConverterJson();
                        Result.ModelContext = json.DeserializeFromJson<TContext>(Result.ResponseData);
                    }
                }
                catch (Exception ex)
                {
                    Result.ErrorCode = -1;
                    Result.ResponseData = ex.Message;
                }

                return Result;
            }          
        }
        public async Task<HttpResultData<TContext>> HTTPGetMessages<TContext>(string Url) 
            where TContext : class, new()
        {            
            using (await mutex.LockAsync())
            {
                HttpResultData<TContext> Result = new HttpResultData<TContext>();
                try
                {
                    Result = await HttpGetReponseMessage<TContext>(Url);

                    if (Result.ErrorCode == 0)
                    {
                        ConverterJson json = new ConverterJson();
                        Result.ArrayModelContext = json.DeserializeFromArrayJson<TContext>(Result.ResponseData);
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Result.ErrorCode = -1;
                    Result.ResponseData = ex.Message;                 
                }
                return Result;
            }                       
        }   
        public string JoinUriSegments(string uri, params string[] segments)
        {
            if (string.IsNullOrWhiteSpace(uri))
                return null;

            if (segments == null || segments.Length == 0)
                return uri;

            return segments.Aggregate(uri, (current, segment) => $"{current.TrimEnd('/')}/{segment.TrimStart('/')}");
        } 
    }

}
