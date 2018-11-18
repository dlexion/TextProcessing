using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextProcessing.TextObjectModel.Interfaces;

namespace TextProcessing.Parsing
{
    public interface ITextParser
    {
        void Parse(IText text, StreamReader sr);

        ICollection<ISentenceElement> ParseLine(string line);
    }
}
