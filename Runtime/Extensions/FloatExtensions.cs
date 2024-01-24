using UnityEngine;

namespace Utilities.Extensions
{
    public static class FloatExtensions
    {
        public static float Squared(this float value)
        {
            return value * value;
        }

        public static float ToPercentIncrease(this float value)
        {
            return Mathf.Round(value * 100f - 100f);
        }

        public static float ToPercent(this float value)
        {
            return value * 100f;
        }
    }
}