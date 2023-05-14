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
        public Type TargetType { get; private set; }
        public string PropertyName { get; private set; }

        public ConfigHandler(Type type)
        {
            TargetType = type;
        }

        public ConfigHandler(Type type, string propertyName)
        {
            TargetType = type;
            PropertyName = propertyName;
        }
    }
}
