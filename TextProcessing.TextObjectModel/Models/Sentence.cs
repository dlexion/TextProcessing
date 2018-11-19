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
    [KnownType(typeof(SentenceElement))]
    public class Sentence : ISentence
    {
        [DataMember(Name = "Sentence")]
        private List<ISentenceElement> _elements;

        public List<ISentenceElement> Elements
        {
            get => _elements;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("SentenceElement");
                }

                _elements = value;
            }
        }

        private Sentence()
        {
            Elements = new List<ISentenceElement>();
        }

        public Sentence(IEnumerable<ISentenceElement> elements) : this()
        {
            Elements.AddRange(elements);
        }

        public int Count
        {
            get => Elements.Count;
        }

        public ICollection<T> GetElements<T>(Func<T, bool> selector = null) where T : ISentenceElement
        {
            return selector == null ?
                new List<T>(Elements.OfType<T>().ToList()) :
                new List<T>(Elements.OfType<T>().Where(selector).ToList());
        }

        public bool IsInterrogative()
        {
            if (Elements.Last() is ISeparator lastElement)
            {
                return lastElement.IsQuestionMark();
            }

            return false;
        }

        public ICollection<ISentenceElement> RemoveAll<T>(Predicate<T> predicate) where T : ISentenceElement
        {
            var resultCollection = new List<ISentenceElement>(Elements.ToList());
            var appropriateElements = GetAppropriateElements(predicate);

            if (appropriateElements.Any())
            {
                RemoveWords(appropriateElements, resultCollection);
            }

            return resultCollection;
        }

        public ICollection<ISentenceElement> InsertInsteadOf<T>(Predicate<T> predicate,
            IList<ISentenceElement> elements)
            where T : ISentenceElement
        {
            var resultCollection = new List<ISentenceElement>(Elements.ToList());
            var appropriateElements = GetAppropriateElements(predicate);

            if (appropriateElements.Any())
            {
                foreach (var item in appropriateElements)
                {
                    int index = RemoveWord(item, resultCollection, true);
                    resultCollection = InsertRange(index, elements, resultCollection);
                }
            }

            return resultCollection;
        }


        private int RemoveWord(ISentenceElement word, IList<ISentenceElement> collection, bool toInsert = false)
        {
            var index = collection.IndexOf(word);

            bool lastButNotSole = (index == collection.Count - 2) && (index > 0);

            bool lastBeforeRemoving = (collection.OfType<Word>().Last().Equals(word));

            collection.Remove(word);

            if (toInsert)
            {
                if (!lastBeforeRemoving)
                {
                    RemoveSeparatorBeforeWord(lastButNotSole, index, collection);
                }
            }
            else
            {
                RemoveSeparatorBeforeWord(lastButNotSole, index, collection);
            }

            return index;
        }

        private void RemoveSeparatorBeforeWord(bool lastButNotSole, int index, IList<ISentenceElement> collection)
        {
            //If it is last word and there are more then 1 words in sentence,
            //then remove separator before word
            if (lastButNotSole)
            {
                index--;
            }
            collection.RemoveAt(index);
        }

        private void RemoveWords<T>(ICollection<T> words, IList<ISentenceElement> collection) where T : ISentenceElement
        {
            foreach (var item in words)
            {
                RemoveWord(item, collection);
            }
        }

        private ICollection<T> GetAppropriateElements<T>(Predicate<T> predicate)
        {
            return Elements.OfType<T>().ToList().FindAll(predicate);
        }

        private List<ISentenceElement> InsertRange(int index,
            IList<ISentenceElement> elementsToInsert,
            List<ISentenceElement> collection)
        {
            var currentIndex = collection.Count;

            collection.InsertRange(index, elementsToInsert);

            if (collection.Last().Equals(collection[index + elementsToInsert.Count]))
            {
                collection.RemoveAt(index + elementsToInsert.Count - 1);
            }

            return collection;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in Elements)
            {
                stringBuilder.Append(item.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}
