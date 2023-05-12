using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Enums;

namespace ValheimPlusRewrite.Configurations.Abstracts
{
    public abstract class ServerSyncConfig : BaseConfig
    {
        [LoadingOption(LoadingMode.Never)]
        public override bool NeedsServerSync { get; set; } = true;
    }
}
