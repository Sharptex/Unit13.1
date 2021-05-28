using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit13._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int attempts = 100;

            string textFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Text1.txt");
            var source = LoadData(textFile);

            List<string> simpleList = new List<string>();
            LinkedList<string> linkedList = new LinkedList<string>();

            var watch = Stopwatch.StartNew();

            double meanSimpleList = 0;
            for (int i = 0; i < attempts; i++)
            {
                watch.Restart();
                foreach (var item in source)
                {
                    simpleList.Add(item);
                }
                watch.Stop();
                meanSimpleList += watch.Elapsed.TotalMilliseconds;
                simpleList.Clear();
            }

            Console.WriteLine($"Среднее время на добавление элементов в List<string>: {meanSimpleList / attempts}  мс");


            double meanLinkedList = 0;
            for (int i = 0; i < attempts; i++)
            {
                watch.Restart();
                foreach (var item in source)
                {
                    linkedList.AddLast(item);
                }
                watch.Stop();
                meanLinkedList += watch.Elapsed.TotalMilliseconds;
                linkedList.Clear();
            }

            Console.WriteLine($"Среднее время на добавление элементов в LinkedList<string>: {meanLinkedList / attempts}  мс");

            Console.ReadKey();
        }

        public static string[] LoadData(string path)
        {
            var result = new List<string>();

            var text = File.ReadAllText(path);
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            char[] separators = new[] { ' ' };
            var words = noPunctuationText.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            return words;
        }
    }
}
