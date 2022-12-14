using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            int value = Challenge2();
            Console.WriteLine(value);
            Console.ReadLine();

        }

        private static int Challenge1()
        {
            string[] lines = File.ReadAllLines(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "input.txt"));

            var highestStack = new Stack<int>();
            var curStack = new Stack<int>();

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    if (curStack.Sum() >= highestStack.Sum())
                    {
                        highestStack = curStack;
                    }
                    curStack = new Stack<int>();
                }
                else
                {
                    curStack.Push(Convert.ToInt32(line));
                }
            }
            return highestStack.Sum();
        }

        private static int Challenge2()
        {
            string[] lines = File.ReadAllLines(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "input.txt"));

            List<int> listOfGoods = new List<int>();

            Stack<int> curKalories = new Stack<int>();
            foreach (var line in lines)
            {
                if(string.IsNullOrEmpty(line))
                {
                    if (listOfGoods.Count < 3)
                    {
                        listOfGoods.Add(curKalories.Sum());
                    }
                    else if (curKalories.Sum() >= listOfGoods[2])
                    {
                        listOfGoods[2] = curKalories.Sum();

                    }
                    listOfGoods = listOfGoods.OrderByDescending(x => x).ToList();
                    curKalories = new Stack<int>();
                }
                else
                {
                    int value = Convert.ToInt32(line);
                    curKalories.Push(value);
                }
                
            }
            int result = 0;
            listOfGoods.ForEach(x => result += x);
            return result;
        }
    }
}
