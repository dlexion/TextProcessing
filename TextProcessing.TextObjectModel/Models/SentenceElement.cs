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
        private string _symbols = string.Empty;

        public virtual string Symbols
        {
            get => _symbols;
            protected set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Symbols");
                }

                _symbols = value;
            }
        }

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
