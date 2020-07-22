using System;

namespace API.Helpers
{
    /// <summary> The FloatingNumberHelper class. Use to compare double values</summary>
    public static class FloatingNumberHelper
    {
        private const double EPSILON = 0.000001d;

        /// <summary> An equality method for floating number in goal to manage imprecision of the type </summary>
        /// <param name="value"></param>
        /// <param name="compareTo"></param>
        /// <param name="epsilon">define imprecision number</param>
        /// <returns></returns>
        public static bool EqualsWithDigitPrecision(this double value, double compareTo, double epsilon)
        {
            return Math.Abs(value - compareTo) < epsilon;
        }

        /// <summary> An equality method for floating number in goal to manage imprecision of the type, using default  acceptable imprecision step between two value </summary>
        /// <param name="value"></param>
        /// <param name="compareTo"></param>
        /// <returns></returns>
        public static bool NearlyEqual(this double value, double compareTo)
        {
            return value.EqualsWithDigitPrecision(compareTo, EPSILON);
        }

    }
}