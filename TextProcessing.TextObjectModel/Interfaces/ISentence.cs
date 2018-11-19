using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextProcessing.TextObjectModel.Interfaces
{
    public interface ISentence
    {
        int Count { get; }

        ICollection<T> GetElements<T>(Func<T, bool> selector = null) where T : ISentenceElement;

        bool IsInterrogative();

        ICollection<ISentenceElement> RemoveAll<T>(Predicate<T> predicate) where T : ISentenceElement;
    }
}
