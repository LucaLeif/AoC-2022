using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName,"input.txt");
            int result = Challenge2(path);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        private static int Challenge1(string path)
        {
            int result = 0;
            string[] lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                List<char> list = new List<char>();
                // Falls input ungerade ist kommt ein Fehler
                // Da aber in der Challenge nicht steht auf welche Seite das letze soll behandel ich es erstmal nicht
                // da es evtl schon im vorhinein rausgenommen wurde und immer gerade ist.
                int length = line.Length;
                string firstCompartment = line.Substring(0, length / 2);
                string secondCompartment = line.Substring(length/2, length / 2);
                foreach (var subString in firstCompartment)
                {
                    if (secondCompartment.Contains(subString))
                    {
                        if (!list.Contains(subString))
                        {
                            list.Add(subString);
                        }
                    }
                }
                result += GetValueFromList(list);
            }
            return result;
        }

        private static int Challenge2(string path)
        {
            int result = 0;
            string[] lines = File.ReadAllLines(path);
            int multiplikctor = 3; 
            for (int i = 0; i < lines.Length; i+=multiplikctor)
            {
                List<int> list = new List<int>();
                List<string> group = new List<string>();
                for (int x = 0; x < multiplikctor; x++)
                {
                    group.Add(lines[i + x]);
                }
                int count = 0;
                foreach (var item in lines[i])
                {
                    bool badge = true;
                    foreach (var line in group)
                    {
                        if (!line.Contains(item))
                        {
                            badge = false;
                        }
                    }
                    if (badge)
                    {
                        if (ChallengeTranslator.TryGetValue(item, out int value))
                        {
                            if (!list.Contains(value))
                            {
                                list.Add(value);
                            }
                        }
                    }
                }
                        
                result += list.Sum();
                list = new List<int>();
            }
            return result;
        }


        private static Dictionary<char, int> ChallengeTranslator = new Dictionary<char, int>()
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
            {'z',26 },
            {'A',27 },
            {'B',28 },
            {'C',29},
            {'D',30 },
            {'E',31 },
            {'F',32 },
            {'G',33 },
            {'H',34 },
            {'I',35 },
            {'J',36 },
            {'K',37 },
            {'L',38 },
            {'M',39 },
            {'N',40 },
            {'O',41 },
            {'P',42 },
            {'Q',43 },
            {'R',44 },
            {'S',45 },
            {'T',46 },
            {'U',47 },
            {'V',48 },
            {'W',49 },
            {'X',50 },
            {'Y',51 },
            {'Z',52 }
        };

        private static int GetValueFromList(List<char> list)
        {
            List<int> countingList = new List<int>();
            foreach (var content in list)
            {
                ChallengeTranslator.TryGetValue(content, out int value);
                countingList.Add(value);
            }
            return countingList.Sum();
        }
    }
}
