using System;
using System.Text;

namespace NET.S._2018.Haiduk._04_05
{
    /// <summary>
    /// Class that contains methods for calculating GCD and extension methods
    /// </summary>
    public static class ExtensionMethods
    {        
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
    }                    
}