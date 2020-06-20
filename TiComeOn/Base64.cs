using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiCome
{
    public static class Base64
    {
        public static string DecodeBase64(string val)
        {
            return Encoding.UTF8.GetString(Base64.DecodeBase64ToBytes(val));
        }
        public static byte[] DecodeBase64ToBytes(string val)
        {
            string s = val.PadRight(val.Length + (4 - val.Length % 4) % 4, '=');
            return Convert.FromBase64String(s);
        }
        public static string EncodeUrlSafeBase64(byte[] val, bool trim)
        {
            if (trim)
            {
                return Convert.ToBase64String(val).Replace('+', '-').Replace('/', '_').TrimEnd(new char[]
                {
                    '='
                });
            }
            return Convert.ToBase64String(val).Replace('+', '-').Replace('/', '_');
        }
        public static byte[] DecodeUrlSafeBase64ToBytes(string val)
        {
            string s = val.Replace('-', '+').Replace('_', '/').PadRight(val.Length + (4 - val.Length % 4) % 4, '=');
            return Convert.FromBase64String(s);
        }
        public static string EncodeUrlSafeBase64(string val, bool trim = true)
        {
            return Base64.EncodeUrlSafeBase64(Encoding.UTF8.GetBytes(val), trim);
        }
        public static string DecodeUrlSafeBase64(string val)
        {
            return Encoding.UTF8.GetString(Base64.DecodeUrlSafeBase64ToBytes(val));
        }
        public static string DecodeStandardSSRUrlSafeBase64(string val)
        {
            if (val.IndexOf('=') >= 0)
            {
                throw new FormatException();
            }
            return Encoding.UTF8.GetString(Base64.DecodeUrlSafeBase64ToBytes(val));
        }
    }
}
