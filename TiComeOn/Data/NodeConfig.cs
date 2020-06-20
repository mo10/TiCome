﻿using Newtonsoft.Json;

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

        [JsonIgnore]
        public long ping = -1; // -1: no tested; -2: in process; -3 failed;
        [JsonIgnore]
        public string country = string.Empty;
        [JsonIgnore]
        public object Tag = null;
    }
    public class IPSBObject
    {
        public string organization { get; set; }
        public string longitude { get; set; }
        public string timezone { get; set; }
        public string isp { get; set; }
        public string offset { get; set; }
        public string asn { get; set; }
        public string asn_organization { get; set; }
        public string country { get; set; }
        public string ip { get; set; }
        public string latitude { get; set; }
        public string continent_code { get; set; }
        public string country_code { get; set; }
    }
}
