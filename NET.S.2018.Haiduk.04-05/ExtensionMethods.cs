using System;
using System.Text;

namespace Day4_5Tasks2_4
{    
    /// <summary>
    /// Class that contains methods for calculating GCD and extension methods
    /// </summary>
    public static class ExtensionMethods
    {
        #region Methods for calculating GCD
        #region Public methods
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
        #endregion

        #region Convert Methods
        /// <summary>
        /// Method that accepts double number and returns its binary representation
        /// </summary>
        /// <param name="number">Double number to convert</param>
        /// <returns>Binary representation of given number as a string</returns>
        public static string BitConvert(this double number)
        {
            StringBuilder byteString = new StringBuilder();
            byte[] byteArray = BitConverter.GetBytes(number);
            foreach (byte b in byteArray)
            {
                for (int i = 0; i < 8; i++)
                {
                    byteString.Insert(0, ((b >> i) & 1) == 1 ? "1" : "0");
                }
            }

            return byteString.ToString();
        }

        /// <summary>
        /// Method that convert accepted number in p-base system into decimal
        /// </summary>
        /// <param name="number">Number in p-base system</param>
        /// <param name="basis">Base of given number</param>
        /// <returns>Decimal number</returns>
        public static int IntConvert(this string number, int basis)
        {
            if (string.IsNullOrEmpty(number))
            {
                throw new ArgumentNullException($"{nameof(number)} is empty.");
            }

            if (basis > 16 || basis < 2)
            {
                throw new ArgumentOutOfRangeException($"{nameof(basis)} must be from 2 to 16.");
            }

            return Convert.ToInt32(number, basis);
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