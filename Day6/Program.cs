using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "input.txt");
            int result = Challenge2(path);
            Console.WriteLine(result);
            Console.ReadLine();

        }

        private static int Challenge1(string path)
        {
            int score = 0;
            string line = File.ReadAllText(path);
            int count = 0;
            List<char> list = new List<char>();
            foreach (var character in line)
            {
                list.Add(character);
                count++;
                if (list.Count >= 4 && list.Count != list.Distinct().Count())
                {
                    list.RemoveAt(0);
                }
                else if (list.Count >= 4)
                {
                    score += count;
                    break;
                }
            }

            return score;
        }

        private static int Challenge2(string path)
        {
            int score = 0;
            string[] lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                int count = 0;
                List<char> list = new List<char>();
                foreach (var character in line)
                {
                    list.Add(character);
                    count++;
                    if (list.Count >= 14 && list.Count != list.Distinct().Count())
                    {
                        list.RemoveAt(0);
                    }
                    else if (list.Count >= 14)
                    {
                        score += count;
                        break;
                    }
                }

            }
            return score;
        }
    }
}
