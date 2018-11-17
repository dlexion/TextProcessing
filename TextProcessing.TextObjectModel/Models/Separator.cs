using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextProcessing.TextObjectModel.Interfaces;

namespace TextProcessing.TextObjectModel.Models
{
    public class Separator : SentenceElement, ISeparator
    {
        public Separator(string symbols) : base(symbols)
        {
        }
    }
}
