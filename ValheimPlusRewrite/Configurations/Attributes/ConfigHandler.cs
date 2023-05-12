using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValheimPlusRewrite.Configurations.Enums;

namespace ValheimPlusRewrite.Configurations.Attributes
{
    public class ConfigHandler : Attribute
    {
        public Type TargetType { get; set; }
        public ConfigHandler(Type type)
        {
            TargetType = type;
        }
    }
}
