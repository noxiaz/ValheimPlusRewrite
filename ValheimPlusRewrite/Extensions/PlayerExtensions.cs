using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValheimPlusRewrite
{
    internal static class PlayerExtensions
    {

        public static Character ToCharacter(this Player __instance)
        {
            return (Character)__instance;
        }
    }
}
