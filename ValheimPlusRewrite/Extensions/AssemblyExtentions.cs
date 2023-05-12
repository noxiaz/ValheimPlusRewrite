using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ValheimPlusRewrite
{
    internal static class AssemblyExtentions
    {
        public static List<Type> GetTypesWithAttribute(this Assembly assembly, Type attribute)
        {
           return assembly.GetTypes().Where(x => x.GetCustomAttributes(attribute, true).Length > 0).ToList();
        }
    }
}
