using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "input.txt");
            List<Stack<char>> list = GetBase(path);
            string result = Challenge2(path,list);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        private static string Challenge1(string path, List<Stack<char>> list)
        {
            string[] lines = File.ReadAllLines(path);
            bool skip = true;
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    skip = false;
                    continue;
                }
                if (skip) continue;

                string[] values = line.Split();
                var newValues = DeleteText(values);

                int countMoves = newValues[0];
                int from = newValues[1];
                int to = newValues[2];

                for (int i = 0; i < countMoves; i++)
                {
                    char value = list[from-1].Pop();
                    list[to-1].Push(value);
                }
            }
            string result = string.Empty;
            foreach (var stack in list)
            {
                result += stack.Peek();
            }
            return result;
        }

        private static string Challenge2(string path, List<Stack<char>> list)
        {
            string[] lines = File.ReadAllLines(path);
            bool skip = true;
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    skip = false;
                    continue;
                }
                if (skip) continue;

                string[] values = line.Split();
                var newValues = DeleteText(values);

                int countMoves = newValues[0];
                int from = newValues[1];
                int to = newValues[2];

                    Stack<char> val = new Stack<char>();
                for (int i = 0; i < countMoves; i++)
                {
                    val.Push(list[from - 1].Pop());
                }

                for (int i = 0; i < countMoves; i++)
                {
                    list[to - 1].Push(val.Pop());
                }
            }
            string result = string.Empty;
            foreach (var stack in list)
            {
                result += stack.Peek();
            }
            return result;
        }

        private static List<int> DeleteText(string[] values)
        {
            List<int> list = new List<int>();
            foreach (var text in values)
            {
                if (int.TryParse(text, out int value))
                {
                    list.Add(value);
                }
            }
            return list;
        }

        private static List<Stack<char>> GetBase(string path)
        {
            string[] lines = File.ReadAllLines(path);
            List<Stack<char>> list = new List<Stack<char>>();
            List<string> construction = new List<string>();
            bool Initialized = false;
            foreach (var line in lines)
            {
                if (Initialized) return list;
                if (!Initialized)
                {
                    Stack<string> stack = new Stack<string>();
                    if (string.IsNullOrEmpty(line))
                    {
                        Initialized = true;
                    }
                    else if(line.Contains("["))
                    {
                        construction.Add(line);
                    }
                    else
                    {
                        List<string> mock = line.Split().ToList();
                        mock.RemoveAll(x => string.IsNullOrEmpty(x));
                        int count = Convert.ToInt32(mock.Last());
                        for (int i = 0; i < count; i++)
                        {
                            int curIndex = (i * 4) + 1;
                            Stack<char> constrStack = new Stack<char>();

                            for (int c = construction.Count-1; c >= 0; c--)
                            {
                                if (construction[c][curIndex] == 32) continue;
                                constrStack.Push(construction[c][curIndex]);
                            }

                            list.Add(constrStack);
                            constrStack = new Stack<char>();
                        }
                    }
                }                
            }
            return list;
        }
    }
}
