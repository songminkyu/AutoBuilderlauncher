using AutoBuilderlauncher.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBuilderlauncher.Model
{
    public class HttpResultData<TContext> where TContext : class, new()
    {
        public HttpResultData()
        {
            ModelContext = new TContext();
            ArrayModelContext = new TContext[] { };
        }
        public string ResponseData { get; set; }
        public int ErrorCode { get; set; } = 0;
        public ApiStatusType ApiStatus { get; set; }
        public TContext ModelContext { get; set; }
        public TContext[] ArrayModelContext { get; set; }

    }
}
