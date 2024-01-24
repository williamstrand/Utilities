using System.Collections.Generic;
using UnityEngine;

namespace Utilities.Extensions
{
    public static class Vector2Extensions
    {
        public static Vector2 Rotate(this Vector2 vector, float angle)
        {
            var sin = Mathf.Sin(angle * Mathf.Deg2Rad);
            var cos = Mathf.Cos(angle * Mathf.Deg2Rad);
            var tx = vector.x;
            var ty = vector.y;
            vector.x = cos * tx - sin * ty;
            vector.y = sin * tx + cos * ty;

            return vector;
        }

        public static RaycastHit2D[] CircleCastAll(this Vector2 position, float radius, int layerMask)
        {
            return Physics2D.CircleCastAll(position, radius, Vector2.zero, 0, layerMask);
        }

        public static RaycastHit2D[] CircleCastAll(this Vector2 position, float radius)
        {
            return Physics2D.CircleCastAll(position, radius, Vector2.zero, 0);
        }

        public static T GetClosest<T>(this Vector2 origin, List<T> ignore = null, float range = Mathf.Infinity) where T : IPosition
        {
            var closest = default(T);
            var closestDistance = float.MaxValue;

            var all = new List<T>();

            origin.CircleCastAll(range).ForEach(CheckIfValid);

            foreach (var item in all)
            {
                if (ignore != null)
                {
                    if (ignore.Contains(item))
                    {
                        continue;
                    }
                }

                var distance = Vector2.Distance(origin, item.Position);
                if (!(distance < closestDistance)) continue;

                closest = item;
                closestDistance = distance;
            }

            return closest;

            void CheckIfValid(RaycastHit2D hit)
            {
                if (!hit.transform) return;

                var item = hit.collider.GetComponent<T>();
                if (item != null) all.Add(item);
            }
        }
    }
}