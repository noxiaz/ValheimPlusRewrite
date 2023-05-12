using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValheimPlusRewrite.Utilities.Models
{
    internal class RpcDataModel
    {
        public string Name { get; set; }
        public long Target { get; set; } = ZRoutedRpc.Everybody;
        public object[] Payload { get; set; }
    }
}
