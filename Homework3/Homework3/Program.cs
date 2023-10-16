using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Homewrok2
{
    internal class Program
    {
        static StreamReader text1 = new StreamReader("C:\\Book.txt");
        static string text=text1.ReadToEnd();
        static List<string> words = new List<string>();
        static string WS;
        static string WL;
        static double avrL;
        static List<string> revL = new List<string> ();

        static bool thread1;
        static bool thread2;
        static bool thread3;
        static bool thread4;
        static bool thread5;
        static bool thread6;



        static void wordsCount()
        {
            Console.WriteLine("Count of words:" + words.Count);

            var shortestWord = words[0];
            for (int i = 1; i < words.Count; i++)
            {
                if (shortestWord.Length > words[i].Length)
                {
                    shortestWord = words[i];
                    WS = shortestWord;
                }
            }
            thread1 = false;
        }

        static void shortWord()
        {
            string shortestWord = WS;
            Console.WriteLine("Shortest word:" + shortestWord);
            Console.WriteLine();

            var longestWord = words[0];
            for (int i = 1; i < words.Count; i++)
            {
                if (longestWord.Length < words[i].Length)
                {
                    longestWord = words[i];
                    WL = longestWord;
                }
            }
            thread2 = false;
        }

        static void longesWord()
        {
            string longestWord = WL;
            Console.WriteLine("longestWord:" + longestWord);
            Console.WriteLine();

            var avarage = 0.0;
            for (int i = 1; i < words.Count; i++)
            {
                avarage += (words[i].Length + 0.0) / words.Count;
                avrL = avarage;
            }
            thread3 = false;
        }

        static void averageLenght()
        {
            double avarage = avrL;
            Console.WriteLine("Average:" + avarage);
            Console.WriteLine();

            var ocurrancies = new Dictionary<string, int>();

            for (int i = 1; i < words.Count; i++)
            {
                if (ocurrancies.ContainsKey(words[i]))
                {
                    ocurrancies[words[i]] = ocurrancies[words[i]] + 1;
                }
                else
                {
                    ocurrancies.Add(words[i], 1);
                }
            }
            thread4 = false;
        }

        static void leatUsed5()
        {
            double avarage = avrL;
            var ocurrancies = new Dictionary<string, int>();

            for (int i = 1; i < words.Count; i++)
            {
                if (ocurrancies.ContainsKey(words[i]))
                {
                    ocurrancies[words[i]] = ocurrancies[words[i]] + 1;
                }
                else
                {
                    ocurrancies.Add(words[i], 1);
                }
            }
            var reverse = new Dictionary<int, List<string>>();
            var enumer = ocurrancies.GetEnumerator();

            while (enumer.MoveNext())
            {
                var curr = enumer.Current;
                if (reverse.ContainsKey(curr.Value))
                {
                    reverse[curr.Value].Add(curr.Key);
                }
                else
                {
                    reverse[curr.Value] = new List<string>() { curr.Key };

                }
            }
            Console.WriteLine("Least five words used");
            var t = new List<int>(reverse.Keys).ToArray();
            Array.Sort(t);
            var showed = 0;
            for (int i = 0; i < Math.Min(5, t.Length) && showed < 5; i++)
            {
                foreach (var element in reverse[t[i]])
                {
                    Console.WriteLine(element + " " + t[i]);
                    showed++;
                }
            }
            thread5 = false;

        }
        static void mostUsed5()
        {
            double avarage = avrL;
            var ocurrancies = new Dictionary<string, int>();
            for (int i = 1; i < words.Count; i++)
            {
                if (ocurrancies.ContainsKey(words[i]))
                {
                    ocurrancies[words[i]] = ocurrancies[words[i]] + 1;
                }
                else
                {
                    ocurrancies.Add(words[i], 1);
                }
            }
            var reverse = new Dictionary<int, List<string>>();
            var enumer = ocurrancies.GetEnumerator();
            while (enumer.MoveNext())
            {
                var curr = enumer.Current;
                if (reverse.ContainsKey(curr.Value))
                {
                    reverse[curr.Value].Add(curr.Key);
                }
                else
                {
                    reverse[curr.Value] = new List<string>() { curr.Key };
                }
            }
            var t = new List<int>(reverse.Keys).ToArray();
            Array.Sort(t);
            var showed = 0;
            
            Console.WriteLine("MOST words used");

            Array.Sort(t, (a, b) => b - a);
            showed = 0;
            for (int i = 0; i < Math.Min(5, t.Length) && showed < 5; i++)
            {
                foreach (var element in reverse[t[i]])
                {
                    Console.WriteLine(element + " " + t[i]);
                    showed++;
                }
            }
            thread6 = false;
        }
        static void Main(string[] args)
        {

            var wordState = "";
            Regex rx = new Regex(@"[a-zA-Z0-9а-яА-Я]");
            for (var i = 0; i < text.Length; i++)
            {
                var c = text[i];
                if (rx.Match(c + "").Success)
                {
                    wordState += c;
                    if (i == text.Length - 1)
                    {
                        words.Add(wordState);
                    }
                }
                else
                {
                    if (wordState.Length >= 3)
                    {
                        words.Add(wordState);
                    }
                    wordState = "";
                }


                
            }



            Thread count = new Thread(wordsCount);
            thread1 = true;
            count.Start();
            while (thread1)
            {
                Thread.Sleep(1000);
            }
            Console.WriteLine("Thread 1 complete.");
            Console.WriteLine();
            Console.WriteLine("Starting thread 2");
            Console.WriteLine();

            Thread TH2 = new Thread(shortWord);
            thread2 = true;
            TH2.Start();
            while (thread2)
            {
                
                Thread.Sleep(1000);
            }
            Console.WriteLine("Thread 2 complete.");
            Console.WriteLine();
            Console.WriteLine("Starting thread 3");
            Console.WriteLine();

            Thread TH3 = new Thread(longesWord);
            thread3 = true;
            TH3.Start();
            while (thread3)
            {
                Thread.Sleep(1000);
            }
            Console.WriteLine("Thread 3 complete.");
            Console.WriteLine();
            Console.WriteLine("Starting thread 4");
            Console.WriteLine();
            Thread TH4 = new Thread(averageLenght);
            thread4 = true;
            TH4.Start();
            while (thread4)
            {
                Thread.Sleep(1000);
            }
            Console.WriteLine("Thread 4 complete.");
            Console.WriteLine();
            /*Console.WriteLine("Starting thread 5");
            Console.ReadLine();
            
            Thread TH5 = new Thread(leatUsed5);
            thread5 = true;
            TH5.Start();
            while (thread5)
            {
                Thread.Sleep(1000);
            }
            */
            Console.WriteLine("Starting thread 6");
            Console.WriteLine();
            Thread TH6 = new Thread(mostUsed5);
            thread6 = true;
            TH6.Start();
            while (thread6)
            {
                Thread.Sleep(1000);
            }
            Console.ReadLine();
            Console.WriteLine("Thread 6 complete.");
            Console.WriteLine();



        }
    }
}