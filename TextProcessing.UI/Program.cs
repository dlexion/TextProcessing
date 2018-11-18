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
