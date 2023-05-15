using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValheimPlusRewrite.Configurations.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class ConfigDescription : Attribute
    {
        public string Description { get; set; } 
        public ConfigDescription(string description)
        {
            Description = description;
        }
    }
}
