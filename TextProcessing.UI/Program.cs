using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextProcessing.Parsing;
using TextProcessing.TextObjectModel.Models;

namespace TextProcessing.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var inputPath = ConfigurationManager.AppSettings["InputPath"];

                var text = new Text();
                var p = new TextParser();

                using (var sr = new StreamReader(inputPath))
                {
                    p.Parse(text, sr);
                }

                Console.WriteLine("Text:");
                Console.WriteLine(text);

                //Вывести все предложения заданного текста 
                //в порядке возрастания количества слов в каждом из них.

                #region Task1 implementation

                var sortedSentences = text.GetSentences().OrderBy(x => x.GetElements<Word>().Count);

                Console.WriteLine("Task 1");
                foreach (var item in sortedSentences)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();

                #endregion
            }
            catch (ConfigurationErrorsException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
