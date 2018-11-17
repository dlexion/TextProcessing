using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextProcessing.TextObjectModel.Interfaces;

namespace TextProcessing.TextObjectModel.Models
{
    public abstract class SentenceElement : ISentenceElement
    {
        public virtual string Symbols { get; protected set; } = string.Empty;

        public SentenceElement(string symbols)
        {
            Symbols = symbols;
        }

        public override string ToString()
        {
            return Symbols;
        }
    }
}
