using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValheimPlusRewrite
{
    internal static class FloatExtensions
    {
        public static float Truncate(this float value, int digits)
        {
            double mult = Math.Pow(10.0, digits);
            double result = Math.Truncate(mult * value) / mult;
            return (float)result;
        }

        public static float ApplyProcentage(this float targetValue, float procentage)
        {
            if (procentage <= -100)
                procentage = -100;

            float newValue;
            if (procentage >= 0)
            {
                newValue = targetValue + ((targetValue / 100) * procentage);
            }
            else
            {
                newValue = targetValue - ((targetValue / 100) * (procentage * -1));
            }

            return newValue;
        }
    }
}
