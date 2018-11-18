using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TextProcessing.TextObjectModel.Interfaces;
using TextProcessing.TextObjectModel.Models;

namespace TextProcessing.Parsing
{
    public class TextParser
    {
        public void Parse(IText text, StreamReader sr)
        {
            if (sr == null)
            {
                throw new ArgumentNullException();
            }

            string line;

            ICollection<ISentenceElement> elements = new List<ISentenceElement>();

            while ((line = sr.ReadLine()) != null)
            {
                line = String.Concat(line, " ");
                line = Regex.Replace(line, "[\f\n\r\t\v]", " ");

                elements = ParseLine(line, elements, text);
            }
        }

        public ICollection<ISentenceElement> ParseLine(string line)
        {
            return ParseLine(line, null, null);
        }

        private ICollection<ISentenceElement> ParseLine(string line, ICollection<ISentenceElement> elements, IText text = null)
        {
            if (elements == null)
            {
                elements = new List<ISentenceElement>();
            }

            string[] sentenceSeparators = new string[] { "...", ".", "!?", "?!", "!", "?" };

            string pattern = @"\b(\w+)((\p{P}{0,3})\s?)";

            foreach (Match match in Regex.Matches(line, pattern))
            {
                elements.Add(new Word(match.Groups[1].ToString()));

                elements.Add(new Separator(match.Groups[2].ToString()));

                var res = sentenceSeparators.Any(x => x.Equals(match.Groups[2].ToString().TrimEnd(' ')));

                if (res)
                {
                    CreateSentence(text, elements);
                    elements = new List<ISentenceElement>();
                }
            }

            return elements;
        }

        private void CreateSentence(IText text, ICollection<ISentenceElement> elements)
        {
            if (text != null)
            {
                text.Add(new Sentence(elements));
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
    }
}
