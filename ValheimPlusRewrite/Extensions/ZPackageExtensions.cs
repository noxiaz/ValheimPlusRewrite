using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValheimPlusRewrite.Handlers.Syncs.Models;

namespace ValheimPlusRewrite
{
    internal static class ZPackageExtensions
    {
        public static MapRangeModel ReadMapRange(this ZPackage pkg)
        {
            var mapRange = new MapRangeModel()
            {
                StartingX = pkg.m_reader.ReadInt32(),
                EndingX = pkg.m_reader.ReadInt32(),
                Y = pkg.m_reader.ReadInt32()
            };

            return mapRange;
        }

        public static void WriteMapRange(this ZPackage pkg, MapRangeModel mapRange)
        {
            pkg.m_writer.Write(mapRange.StartingX);
            pkg.m_writer.Write(mapRange.EndingX);
            pkg.m_writer.Write(mapRange.Y);
        }
    }
}
