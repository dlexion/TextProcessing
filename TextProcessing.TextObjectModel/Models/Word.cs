using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextProcessing.TextObjectModel.Interfaces;

namespace TextProcessing.TextObjectModel.Models
{
    public class Word : SentenceElement, IWord
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
