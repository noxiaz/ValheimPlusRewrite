using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValheimPlusRewrite.Configurations.Enums;

namespace ValheimPlusRewrite.Configurations.Attributes
{
    public class LoadingOption : Attribute
    {
        public LoadingMode LoadingMode { get; }
        public LoadingOption(LoadingMode loadingMode)
        {
            LoadingMode = loadingMode;
        }
    }
}
