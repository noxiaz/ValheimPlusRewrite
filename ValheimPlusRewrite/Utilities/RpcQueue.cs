using BepInEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValheimPlusRewrite.Utilities.Models;

namespace ValheimPlusRewrite.Utilities
{
    internal static class RpcQueue
    {
        private static Queue<RpcDataModel> rpcQueue = new Queue<RpcDataModel>();
        private static bool ack = true;

        public static void Enqueue(RpcDataModel rpc)
        {
            rpcQueue.Enqueue(rpc);
        }

        public static bool SendNextRpc()
        {
            if (rpcQueue.Count == 0 || !ack) return false;

            RpcDataModel rpc = rpcQueue.Dequeue();

            if (rpc.Name.IsNullOrWhiteSpace() ||
                rpc.Payload == null)
            {
                return false;
            }

            ZRoutedRpc.instance.InvokeRoutedRPC(rpc.Target, rpc.Name, rpc.Payload);
            ack = false;

            return true;
        }

        public static void GotAck()
        {
            ack = true;
        }
    }
}
