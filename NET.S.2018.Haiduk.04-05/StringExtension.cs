using System;

namespace NET.S._2018.Haiduk._04_05
{
    /// <summary>
    /// Class that contains extension method for converting from 2 to 16 notation into decimal
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Method for converting from 2 to 16 notation into decimal
        /// </summary>
        /// <param name="source">Number in some notation as a string</param>
        /// <param name="notation">Description of notation</param>
        /// <returns>Decimal number</returns>
        public static int ToDecimalConverter(this string source, Notation notation)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentNullException($"{nameof(source)} is empty.");
            }

            int result = 0;

            for (int i = 0, j = source.Length - 1; i < source.Length; i++)
            {
                result += (int)Math.Pow(notation.Basis, j - i) * notation.Alphabet.IndexOf(source[i].ToString().ToUpper());
            }

            return result;
        }
    }
}
