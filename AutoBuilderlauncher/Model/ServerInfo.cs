using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBuilderlauncher.Model
{
    public class ServerInfo
    {
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public string? version { get; set; }
    }
}
