using System;

namespace NET.S._2018.Haiduk._04_05
{
    /// <summary>
    /// Class that describes notation
    /// </summary>
    public class Notation
    {
        private string alphabet = "0123456789ABCDEF";

        public Notation(int basis)
        {
            if (basis < 2 || basis > 16)
            {
                throw new ArgumentException($"{nameof(basis)} must be from 2 to 16.");
            }

            Basis = basis;
        }
                
        public int Basis { get; }

        public string Alphabet => alphabet.Substring(0, Basis);
    }
}
