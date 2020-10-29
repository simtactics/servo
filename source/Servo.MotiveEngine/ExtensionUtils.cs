using System;

namespace Servo.MotiveEngine
{
    public static class ExtensionUtils
    {
        public static int MaxLimit(this int val, int max)
        {
            if (max < 0)
                throw new ArgumentOutOfRangeException();

            if (val >= max)
                return max;

            return val;
        }
    }
}
