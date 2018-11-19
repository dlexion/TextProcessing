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

                Console.WriteLine();
                Console.WriteLine("Task 1");

                var sortedSentences = text.GetSentences().OrderBy(x => x.GetElements<Word>().Count);

                foreach (var item in sortedSentences)
                {
                    Console.WriteLine(item);
                }

                #endregion

                //Во всех вопросительных предложениях текста 
                //найти и напечатать без повторений слова заданной
                //длины.

                #region Task2 implementation

                Console.WriteLine();
                Console.WriteLine("Task 2");

                var lenth = 5;

                var words = text.GetSentences(x => x.IsInterrogative())
                                .SelectMany(y => y.GetElements<Word>(x => x.Length == lenth))
                                .Distinct();

                foreach (var item in words)
                {
                    Console.WriteLine(item);
                }

                #endregion

                //Из текста удалить все слова заданной длины, начинающиеся на согласную букву.

                #region Task3 implementation

                Console.WriteLine();
                Console.WriteLine("Task 3");

                int wordLenght = 4;

                var result = text.GetSentences()
                    .Select(x => new Sentence(
                        x.RemoveAll<Word>(y => (y.Length == wordLenght) && y.StartWithConsonant())))
                    .Where(x => x.Count > 0).ToList();

                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }

                #endregion

                #region Task4 implementation
                Console.WriteLine();
                Console.WriteLine("Task 4");

                var wordToReplaceLenght = 4;

                var sentenceId = 0;

                var substring = "a simple string to insert";

                Console.WriteLine(text.GetSentenceById(sentenceId));

                var wordsAfterReplace = text.GetSentenceById(sentenceId)
                    .InsertInsteadOf<Word>(y => y.Length == wordToReplaceLenght, p.ParseLine(substring));

                var newSentence = new Sentence(wordsAfterReplace);
                Console.WriteLine(newSentence);

                #endregion

                Console.WriteLine();
                Console.WriteLine(text);
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
