using System;

namespace FakeWordle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] wordList = File.ReadAllLines("wordlist.txt");
            string[] allowedList = File.ReadAllLines("allowed.txt");
            Random r = new Random();
            int rInt = r.Next(0, wordList.Length);
            char[] word = wordList[rInt].ToCharArray();
            string w = wordList[rInt];
            //Console.WriteLine(w);
            int i = 0;
            int c = 0;
            string wordp;
            char[] charp = new char[5];
            string guesses = "";
            Console.WriteLine("Enter a guess");
            while (i < 6)
            {
                wordp = Console.ReadLine();
                if(wordp.Length != 5) { Console.WriteLine("Wrong number of characters"); }
                else if ((!(allowedList.Contains(wordp))&&!(wordList.Contains(wordp)))) { Console.WriteLine(wordp+ " is not a valid guess"); }
                else
                {
                    charp = wordp.ToCharArray();
                    if (w == wordp)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(wordp);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Nice");
                        break;
                    }
                    while (c < 5)
                    {
                        if(charp[c] == word[c])
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(charp[c]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (w.Contains(charp[c]))
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(charp[c]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(charp[c]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        c++;
                    }
                    c=0;
                    i++;
                    Console.WriteLine(" " + i + "/6");
                }
                if (i > 5)
                {
                    Console.WriteLine(":(");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(w);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.ReadKey();
            }
        }
    }
}