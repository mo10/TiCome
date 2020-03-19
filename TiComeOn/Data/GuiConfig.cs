using Newtonsoft.Json;
using System.Collections.Generic;

namespace TiCome.Data
{
    class GuiConfig
    {
        [JsonProperty]
        public IList<NodeConfig> configs;
        [JsonProperty]
        public IList<ServerSubscribe> serverSubscribes;
    }
}
