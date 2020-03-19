using Newtonsoft.Json;

namespace TiCome.Data
{
    class ServerSubscribe
    {
        [JsonProperty]
        public string URL { get; private set; } = string.Empty;
        [JsonProperty]
        public string Group { get; private set; } = string.Empty;
        [JsonProperty]
        public long LastUpdateTime { get; private set; } = 0;
    }
}
