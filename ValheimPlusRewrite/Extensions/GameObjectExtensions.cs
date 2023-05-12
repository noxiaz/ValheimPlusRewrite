using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ValheimPlusRewrite
{
    internal static class GameObjectExtensions
    {
        private static ConcurrentDictionary<float, Stopwatch> stopwatches = new ConcurrentDictionary<float, Stopwatch>();

        public static Stopwatch GetStopwatch(this GameObject o)
        {
            float hash = GetGameObjectPosHash(o);
            Stopwatch stopwatch = null;

            if (!stopwatches.TryGetValue(hash, out stopwatch))
            {
                stopwatch = new Stopwatch();
                stopwatches.TryAdd(hash, stopwatch);
            }

            return stopwatch;
        }

        private static float GetGameObjectPosHash(this GameObject o)
        {
            return (1000f * o.transform.position.x) + o.transform.position.y + (.001f * o.transform.position.z);
        }

        public static T GetChildComponentByName<T>(this GameObject objected, string name) where T : Component
        {
            foreach (T component in objected.GetComponentsInChildren<T>(true))
            {
                if (component.gameObject.name == name)
                {
                    return component;
                }
            }
            return null;
        }
    }
}
