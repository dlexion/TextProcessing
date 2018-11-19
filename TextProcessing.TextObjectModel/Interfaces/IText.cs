using System;
using System.Collections.Generic;

namespace TextProcessing.TextObjectModel.Interfaces
{
    public interface IText
    {
        void Add(ISentence sentence);

        ISentence GetSentenceById(int index);

        ICollection<ISentence> GetSentences(Func<ISentence, bool> selector = null);
    }
}
