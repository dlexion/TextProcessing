using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextProcessing.TextObjectModel.Models
{
    public class Word : SentenceElement
    {
        public Word(string symbols) : base(symbols)
        {
        }

        public int Length
        {
            get => Symbols.Length;
        }
    }
}
