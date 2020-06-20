using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiCome.Data;

namespace TiCome
{
    public static class Server
    {
        public static string GetSSRLinkForServer(NodeConfig nodeConfig)
        {
            string main_part = nodeConfig.server + ":" + nodeConfig.server_port + ":" + nodeConfig.protocol + ":" + nodeConfig.method + ":" + nodeConfig.obfs + ":" + Base64.EncodeUrlSafeBase64(nodeConfig.password);
            string param_str = "obfsparam=" + Base64.EncodeUrlSafeBase64(nodeConfig.obfsparam ?? "");
            if (!string.IsNullOrEmpty(nodeConfig.protocolparam))
            {
                param_str += "&protoparam=" + Base64.EncodeUrlSafeBase64(nodeConfig.protocolparam);
            }
            if (!string.IsNullOrEmpty(nodeConfig.remarks))
            {
                param_str += "&remarks=" + Base64.EncodeUrlSafeBase64(nodeConfig.remarks);
            }
            if (!string.IsNullOrEmpty(nodeConfig.group))
            {
                param_str += "&group=" + Base64.EncodeUrlSafeBase64(nodeConfig.group);
            }
            if (nodeConfig.udp_over_tcp)
            {
                param_str += "&uot=" + "1";
            }
            if (nodeConfig.server_udp_port > 0)
            {
                param_str += "&udpport=" + nodeConfig.server_udp_port.ToString();
            }
            string base64 = Base64.EncodeUrlSafeBase64(main_part + "/?" + param_str);
            return "ssr://" + base64;
        }
    }
}
