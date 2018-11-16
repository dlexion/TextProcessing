using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextProcessing.TextObjectModel.Models
{
    public class Word
    {
        public string Symbols { get; private set; } = string.Empty;

        public Word(string symbols)
        {
            Symbols = symbols;
        }

        public int Length
        {
            get => Symbols.Length;
        }

        public override string ToString()
        {
            return Symbols;
        }
    }
}
