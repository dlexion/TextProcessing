using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TextProcessing.TextObjectModel.Interfaces;

namespace TextProcessing.TextObjectModel.Models
{
    [DataContract(Namespace = "", Name = "Text")]
    [KnownType(typeof(Sentence))]
    public class Text : IText
    {
        [DataMember(Name = "Sentences")]
        private ICollection<ISentence> _sentences = new List<ISentence>();

        public void Add(ISentence sentence)
        {
            if (sentence == null)
            {
                throw new ArgumentNullException("Sentence");
            }

            _sentences.Add(sentence);
        }

        public ISentence GetSentenceById(int index)
        {
            if (index < 0 || index >= _sentences.Count)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            return _sentences.ElementAt(index);
        }

        public ICollection<ISentence> GetSentences(Func<ISentence, bool> selector = null)
        {
            return selector == null ?
                new List<ISentence>(_sentences) :
                new List<ISentence>(_sentences.Where(selector).ToList());
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in _sentences)
            {
                stringBuilder.Append(item.ToString());
            }

            return stringBuilder.ToString();
        }

        public void WriteObject(string fileName)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Create))
            {
                DataContractSerializer serializer = new DataContractSerializer(this.GetType());

                using (var writer = XmlWriter.Create(fileStream, new XmlWriterSettings { Indent = true }))
                {
                    serializer.WriteObject(writer, this);
                }
            }
        }


        public Text ReadObject(string fileName)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Open))
            {
                using (XmlDictionaryReader reader =
                    XmlDictionaryReader.CreateTextReader(fileStream, new XmlDictionaryReaderQuotas()))
                {
                    DataContractSerializer serializer = new DataContractSerializer(this.GetType());

                    Text newText = (Text)serializer.ReadObject(reader, true);

                    return newText;
                }
            }
        }
    }
}
