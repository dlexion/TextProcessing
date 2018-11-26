using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TextProcessing.TextObjectModel.Interfaces;

namespace TextProcessing.TextObjectModel.Models
{
    [DataContract(Namespace = "")]
    public class Separator : SentenceElement, ISeparator
    {
        public Separator(string symbols) : base(symbols)
        {
        }

        public bool IsQuestionMark()
        {
            return Symbols.Contains("?");
        }
    }
}
