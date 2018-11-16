using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextProcessing.TextObjectModel.Models
{
    public class Separator
    {
        public string Symbols { get; set; }

        public Separator(string symbols)
        {
            Symbols = symbols;
        }

        public override string ToString()
        {
            return Symbols;
        }
    }
}
