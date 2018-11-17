﻿using System;
using System.Collections.Generic;

namespace TextProcessing.TextObjectModel.Interfaces
{
    public interface IText
    {
        void Add(ISentence sentence);

        ICollection<ISentence> GetSentences(Func<ISentence, bool> selector = null);
    }
}
