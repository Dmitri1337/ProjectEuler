namespace ProjectEuler.Math
{
    public static partial class XXMath
    {
        public static int GreatestCommonDivisor(int a, int b)
        {
            if (a == b)
                return a;

            if (a == 0)
                return b;

            if (b == 0)
                return a;

            int shift = 0;

            if (a < 0)
                a = -a;
            if (b < 0)
                b = -b;

            // Let shift = lg K, where K is the greatest power of 2 dividing both a and b
            while (((a | b) & 1) == 0)
            {
                shift++;
                a >>= 1;
                b >>= 1;
            }

            while ((a & 1) == 0)
                a >>= 1;

            // From here on, a is always odd
            do
            {
                // remove all factors of 2 in b - they are not common
                // note: b is not zero, so while will terminate
                while ((b & 1) == 0)
                    b >>= 1;

                // Now a and b are both odd. Swap if necessary so a <= b, then set b = b - a (which is even)
                if (a > b)
                {
                    int buf = b;
                    b = a;
                    a = buf;
                }

                b -= a; // Here b >= a.
            } while (b != 0);

            // restore common factors of 2
            return a << shift;
        }
    }
}