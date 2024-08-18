using System;

namespace MinseoMathUtil
{
    public static class MinseoMath
    {
        public static Single Lerp(Single p1, Single p2, Single d1)
        {
            return (1 - d1) * p1 + d1 * p2;
        }
    }
}