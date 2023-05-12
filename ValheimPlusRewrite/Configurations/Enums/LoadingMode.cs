using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValheimPlusRewrite.Configurations.Enums
{
    /// <summary>
    /// Defines, when a property is loaded
    /// </summary>
    public enum LoadingMode
    {
        Always = 0,
        RemoteOnly = 1,
        LocalOnly = 2,
        Never = 3
    }
}
