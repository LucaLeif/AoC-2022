using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12
{
    class Program
    {
        public static Dictionary<char, int> dic = new Dictionary<char, int>()
        {
            {'a',1 },
            {'b',2 },
            {'c',3 },
            {'d',4 },
            {'e',5 },
            {'f',6 },
            {'g',7 },
            {'h',8 },
            {'i',9 },
            {'j',10 },
            {'k',11 },
            {'l',12 },
            {'m',13 },
            {'n',14 },
            {'o',15 },
            {'p',16 },
            {'q',17 },
            {'r',18 },
            {'s',19 },
            {'t',20 },
            {'u',21 },
            {'v',22 },
            {'w',23 },
            {'x',24 },
            {'y',25 },
            {'z',26 }
        };
        public static List<List<char>> Grid = new List<List<char>>();
        public static List<List<int>> GridStepsCount = new List<List<int>>();


        static void Main(string[] args)
        {
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "mock.txt");
            int result = Challenge0(path);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        /// <summary>
        /// Da ich nicht verstehe wie ich da rangehen soll versuche ich erstmal hier was 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static int Challenge0(string path)
        {
            int steps = 0;
            string[] lines = File.ReadAllLines(path);
            Grid = GetGrid(lines);
            int result = MakeSteps(0, 0);
            return steps;
        }

        private static List<List<char>> GetGrid(string[] lines)
        {
            List<List<char>> list = new List<List<char>>();
            List<char> sublist = new List<char>();
            foreach (var line in lines)
            {
                foreach (var substring in line)
                {
                    sublist.Add(substring);
                }
                list.Add(sublist);
                sublist = new List<char>();
            }
            return list;
        }

        private static int MakeSteps(int xStart, int yStart)
        {
            int steps = 0;
            char curChar = Grid[yStart][xStart];
            // Finde den nahsten 
            // steige 1 auf und dann fängt der Prozess von vorne an
            if (yStart < Grid.Count && Grid[yStart + 1][xStart] == curChar)
            {
                MakeSteps(yStart + 1, xStart);
            }
            if (yStart >= 0 && Grid[yStart - 1][xStart] == curChar)
            {
                MakeSteps(yStart - 1, xStart);
            }
            if (xStart < Grid[yStart].Count && Grid[yStart][xStart + 1] == curChar)
            {
                MakeSteps(yStart, xStart + 1);
            }
            if (xStart >= 0 && Grid[yStart][xStart-1] == curChar)
            {
                MakeSteps(yStart, xStart - 1);
            }


            return steps;
        }

    }
}
