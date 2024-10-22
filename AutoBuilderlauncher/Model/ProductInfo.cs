using AutoBuilderlauncher.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AutoBuilderlauncher.Model
{
    public class ProductInfo
    {
        [JsonProperty("path", NullValueHandling = NullValueHandling.Ignore)]
        public string? Path { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("organName", NullValueHandling = NullValueHandling.Ignore)]
        public OrganCategory OrganName { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("productName", NullValueHandling = NullValueHandling.Ignore)]
        public ProductCategory ProductName { get; set; }
    }
}
