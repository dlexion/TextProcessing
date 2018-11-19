using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextProcessing.TextObjectModel.Interfaces;

namespace TextProcessing.TextObjectModel.Models
{
    public class Sentence : ISentence
    {
        private List<ISentenceElement> _elements;

        public Sentence()
        {
            _elements = new List<ISentenceElement>();
        }

        public Sentence(IEnumerable<ISentenceElement> elements) : this()
        {
            _elements.AddRange(elements);
        }

        public int Count
        {
            get => _elements.Count;
        }

        public ICollection<T> GetElements<T>(Func<T, bool> selector = null) where T : ISentenceElement
        {
            return selector == null ?
                new List<T>(_elements.OfType<T>().ToList()) :
                new List<T>(_elements.OfType<T>().Where(selector).ToList());
        }

        public bool IsInterrogative()
        {
            if (_elements.Last() is ISeparator lastElement)
            {
                return lastElement.IsQuestionMark();
            }

            return false;
        }

        public ICollection<ISentenceElement> RemoveAll<T>(Predicate<T> predicate) where T : ISentenceElement
        {
            var appropriateElements = _elements.OfType<T>().ToList().FindAll(predicate);

            if (appropriateElements.Any())
            {
                foreach (var item in appropriateElements)
                {
                    RemoveWord(item);
                }
            }

            return _elements;
        }

        private void RemoveWord(ISentenceElement word)
        {
            var index = _elements.IndexOf(word);

            //If it is last word and there are more then 1 word in sentence,
            //then remove separator before word
            if ((index == _elements.Count - 2) && (index > 0))
            {
                index--;
            }

            _elements.Remove(word);
            _elements.RemoveAt(index);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in _elements)
            {
                stringBuilder.Append(item.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}

