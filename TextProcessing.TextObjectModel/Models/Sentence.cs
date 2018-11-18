﻿using System;
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
                _elements.OfType<T>().ToList() :
                _elements.OfType<T>().Where(selector).ToList();
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