using System;

namespace NET.S._2018.Haiduk._04_05
{
    public class GCDMethods
    {
        #region Public methods
        /// <summary>
        /// Method that calculates GCD for 2 numbers using Euclid algorythm
        /// </summary>
        /// <param name="a">1st number</param>
        /// <param name="b">2nd number</param>
        /// <returns>GCD of given numbers</returns>
        public static int EuclidGCD(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }
            else if (b == 0)
            {
                return a;
            }

            return FindEuclidGDC(a, b);
        }

        /// <summary>
        /// Method that calculates GCD for 3 numbers using Euclid algorythm
        /// </summary>
        /// <param name="a">1st number</param>
        /// <param name="b">2nd number</param>
        /// <param name="c">3rd number</param>
        /// <returns>GCD of given numbers</returns>
        public static int EuclidGCD(int a, int b, int c)
        {
            int[] array = { a, b, c };
            int gcd = array[0];
            for (int i = 0; i < array.Length - 1; i++)
            {
                gcd = FindEuclidGDC(gcd, array[i + 1]);
            }

            return gcd;
        }

        /// <summary>
        /// Method that calculates GCD using Euclid algorythm
        /// </summary>
        /// <param name="array">Array of 2, 3 or more numbers</param>
        /// <returns>GCD of given numbers</returns>
        public static int EuclidGCD(params int[] array)
        {
            if (array.Length == 0 || array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} is empty.");
            }

            if (array.Length == 1)
            {
                return array[0];
            }

            int gcd = array[0];
            for (int i = 0; i < array.Length - 1; i++)
            {
                gcd = FindEuclidGDC(gcd, array[i + 1]);
            }

            return gcd;
        }

        /// <summary>
        /// Method that calculates GCD for 2 numbers using Stein algorythm (Euclid binary algorythm)
        /// </summary>
        /// <param name="a">1st number</param>
        /// <param name="b">2nd number</param>
        /// <returns>GCD of given numbers</returns>
        public static int SteinGCD(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }
            else if (b == 0)
            {
                return a;
            }

            return FindSteinGCD(a, b);
        }

        /// <summary>
        /// Method that calculates GCD for 2 numbers using Stein algorythm (Euclid binary algorythm)
        /// </summary>
        /// <param name="a">1st number</param>
        /// <param name="b">2nd number</param>
        /// <param name="c">3rd number</param>
        /// <returns>GCD of given numbers</returns>
        public static int SteinGCD(int a, int b, int c)
        {
            int[] array = { a, b, c };
            int gcd = array[0];
            for (int i = 0; i < array.Length - 1; i++)
            {
                gcd = FindSteinGCD(gcd, array[i + 1]);
            }

            return gcd;
        }

        /// <summary>
        /// Method that calculates GCD using Stein algorythm (Euclid binary algorythm)
        /// </summary>
        /// <param name="array">Array of 2, 3 or more numbers</param>
        /// <returns>GCD of given numbers</returns>
        public static int SteinGCD(params int[] array)
        {
            if (array.Length == 0 || array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} is empty.");
            }

            if (array.Length == 1)
            {
                return array[0];
            }

            int gcd = array[0];
            for (int i = 0; i < array.Length - 1; i++)
            {
                gcd = FindSteinGCD(gcd, array[i + 1]);
            }

            return gcd;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Supporting method that calculates GCD of 2 given numbers for Euclid algorythm
        /// </summary>
        /// <param name="a">1st give number</param>
        /// <param name="b">2nd given number</param>
        /// <returns>GCD of 2 numbers</returns>
        private static int FindEuclidGDC(int a, int b)
        {
            while (b != 0)
            {
                b = a % (a = b);
            }

            return a;
        }

        /// <summary>
        /// Supporting method that calculates GCD of 2 given numbers for Stein algorythm
        /// </summary>
        /// <param name="a">1st give number</param>
        /// <param name="b">2nd given number</param>
        /// <returns>GCD of 2 numbers</returns>
        private static int FindSteinGCD(int a, int b)
        {
            int k = 1;
            a = Math.Abs(a);
            b = Math.Abs(b);
            while ((a != 0) && (b != 0))
            {
                while ((a % 2 == 0) && (b % 2 == 0))
                {
                    a /= 2;
                    b /= 2;
                    k *= 2;
                }

                while (a % 2 == 0)
                {
                    a /= 2;
                }

                while (b % 2 == 0)
                {
                    b /= 2;
                }

                if (a >= b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }

            return b * k;
        }
        #endregion
    }
}
