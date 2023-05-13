using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValheimPlusRewrite.Configurations.Models
{
    public struct ConfigModel<T> where T : struct, IComparable
    {
        public ConfigModel(T defaultValue, T value)
        {
            DefaultValue = defaultValue;
            Value = value;
        }

        public T DefaultValue { get; set; }
        public T Value { get; set; }
        public bool IsDefault => DefaultValue.Equals(Value);


        public static implicit operator T(ConfigModel<T> c) => c.Value;

        public static implicit operator ConfigModel<T>(T v)
        {
            return new ConfigModel<T>() { DefaultValue = v, Value = v };
        }
    }
}
