using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValheimPlusRewrite
{
    internal static class ZNetExtensions
    {

        public static bool IsLocalInstance(this ZNet znet)
        {
            return znet.IsServer() && !znet.IsDedicated();
        }

        public static bool IsClientInstance(this ZNet znet)
        {
            return !znet.IsServer() && !znet.IsDedicated();
        }

        public static bool IsServerInstance(this ZNet znet)
        {
            return znet.IsServer() && znet.IsDedicated();
        }
    }
}
