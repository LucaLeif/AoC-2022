using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
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
            string[] lines = File.ReadAllLines(path);
            int score = 0;
            foreach (var line in lines)
            {
                List<string> pairs = line.Split(',').ToList();
                Stack<int> firstPairResult = new Stack<int>();
                Stack<int> secondPairResult = new Stack<int>();

                for (int i = 0; i < pairs.Count; i++)
                {
                    string[] values = pairs[i].Split('-');
                    int firstValue = Convert.ToInt32(values[0]);
                    int secondValue = Convert.ToInt32(values[1]);
                    if (i == 0)
                    {
                        int index = firstValue;
                        while (index <= secondValue)
                        {
                            firstPairResult.Push(index);
                            index++;
                        }
                    }
                    else
                    {
                        int index = firstValue;
                        while (index <= secondValue)
                        {
                            secondPairResult.Push(index);
                            index++;
                        }
                    }
                }
                int count = 0;
                int max = firstPairResult.Count;
                foreach (var result in firstPairResult)
                {
                    if(secondPairResult.Contains(result))
                    {
                        count++;
                    }
                }
                if (count == max) 
                {
                    score++;
                    continue;
                }
                else
                {
                    count = 0;
                    max = secondPairResult.Count;
                }
                foreach (var result in secondPairResult)
                {
                    if (firstPairResult.Contains(result))
                    {
                        count++;
                    }
                }
                if (count == max) score++;
            }
            return score;
        }

        private static int Challenge2(string path)
        {
            string[] lines = File.ReadAllLines(path);
            int score = 0;
            foreach (var line in lines)
            {
                List<string> pairs = line.Split(',').ToList();
                Stack<int> firstPairResult = new Stack<int>();
                Stack<int> secondPairResult = new Stack<int>();

                for (int i = 0; i < pairs.Count; i++)
                {
                    string[] values = pairs[i].Split('-');
                    int firstValue = Convert.ToInt32(values[0]);
                    int secondValue = Convert.ToInt32(values[1]);
                    if (i == 0)
                    {
                        int index = firstValue;
                        while (index <= secondValue)
                        {
                            firstPairResult.Push(index);
                            index++;
                        }
                    }
                    else
                    {
                        int index = firstValue;
                        while (index <= secondValue)
                        {
                            secondPairResult.Push(index);
                            index++;
                        }
                    }
                }
                bool increased = false;
                int count = 0;
                int max = firstPairResult.Count;
                foreach (var result in firstPairResult)
                {
                    if (secondPairResult.Contains(result))
                    {
                        score++;
                        increased = true;
                        break;
                    }
                }
                if (increased) continue;
                max = secondPairResult.Count;
                foreach (var result in secondPairResult)
                {
                    if (firstPairResult.Contains(result))
                    {
                        score++;
                        continue;
                    }
                }
            }
            return score;
        }
    }
}
