using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextProcessing.TextObjectModel.Extensions
{
    public static class CharExtension
    {
        private static readonly char[] vovels = new[] { 'a', 'e', 'i', 'o', 'u' };

        public static bool IsVovel(this char symbol)
        {
            return symbol != char.MinValue ? vovels.Contains(char.ToLowerInvariant(symbol)) : false;
        }

        public static bool IsConsonant(this char symbol)
        {
            return !IsVovel(symbol);
        }
    }
}
