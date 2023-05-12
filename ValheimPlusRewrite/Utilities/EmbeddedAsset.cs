using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ValheimPlusRewrite.Utilities
{
    internal static class EmbeddedAsset
    {
        public static Stream LoadEmbeddedAsset(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourcePath = assembly.GetManifestResourceNames().Single(str => str.EndsWith(name));
            return assembly.GetManifestResourceStream(resourcePath);
        }

        public static Texture2D LoadPng(Stream fileStream)
        {
            Texture2D texture = null;
            if (fileStream != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    fileStream.CopyTo(memoryStream);
                    texture = new Texture2D(2, 2);
                    texture.LoadImage(memoryStream.ToArray()); 
                }
            }

            return texture;
        }
    }
}
