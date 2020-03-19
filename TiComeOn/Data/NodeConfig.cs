using Newtonsoft.Json;

namespace TiCome.Data
{
    public class NodeConfig
    {
        [JsonProperty]
        public string remarks { get; private set; } = string.Empty;
        [JsonProperty]
        public string id { get; private set; } = string.Empty;
        [JsonProperty]
        public string server { get; private set; } = string.Empty;
        [JsonProperty]
        public int server_port { get; private set; } = 0;
        [JsonProperty]
        public int server_udp_port { get; private set; } = 0;
        [JsonProperty]
        public string password { get; private set; } = string.Empty;
        [JsonProperty]
        public string method { get; private set; } = string.Empty;
        [JsonProperty]
        public string protocol { get; private set; } = string.Empty;
        [JsonProperty]
        public string protocolparam { get; private set; } = string.Empty;
        [JsonProperty]
        public string obfs { get; private set; } = string.Empty;
        [JsonProperty]
        public string obfsparam { get; private set; } = string.Empty;
        [JsonProperty]
        public string remarks_base64 { get; private set; } = string.Empty;
        [JsonProperty]
        public string group { get; private set; } = string.Empty;
        [JsonProperty]
        public bool enable { get; private set; } = false;
        [JsonProperty]
        public bool udp_over_tcp { get; private set; } = false;
    }
}
