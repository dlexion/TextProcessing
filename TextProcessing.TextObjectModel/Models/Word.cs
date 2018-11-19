using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextProcessing.TextObjectModel.Extensions;
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

        public bool StartWithConsonant()
        {
            return Symbols.FirstOrDefault().IsConsonant();
        }

        public static bool operator ==(Word word1, Word word2)
        {
            return string.Compare(word1.ToString(), word2.ToString(), true) == 0;
        }

        public static bool operator !=(Word word1, Word word2)
        {
            return !(word1 == word2);
        }

        public override bool Equals(object obj)
        {
            return this == (Word)obj;
        }

        public override int GetHashCode()
        {
            return ToString().ToLower().GetHashCode();
        }
    }
}
