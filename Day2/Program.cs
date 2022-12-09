using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        public enum OptionsUser
        {
            X = 1, //Stein
            Y = 2, //Papier
            Z = 3  //Schere
        }
        public enum OptionsEnemy
        {
            A = 1,
            B = 2,
            C = 3
        }

        static void Main(string[] args)
        {
            string[] matches = File.ReadAllLines(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "mock.txt"));

            int result = Challenge2(matches);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        private static int Challenge1(string[] matches)
        {
            int finalResult = 0;
            foreach (var match in matches)
            {
                int resultOfMatch = 0;
                List<string> input = match.Split().ToList();
                switch (input[0])
                {
                    case "A":
                        if (input[1] == "X")
                            finalResult += 4;
                        else if (input[1] == "Y")
                            finalResult += 8;
                        else if (input[1] == "Z")
                            finalResult += 3;
                        break;
                    case "B":
                        if (input[1] == "X")
                            finalResult += 1;
                        else if (input[1] == "Y")
                            finalResult += 5;
                        else if (input[1] == "Z")
                            finalResult += 9;
                        break;
                    case "C":
                        if (input[1] == "X")
                            finalResult += 7;
                        else if (input[1] == "Y")
                            finalResult += 2;
                        else if (input[1] == "Z")
                            finalResult += 6;
                        break;
                    default:
                        break;
                }
            }
            return finalResult;
        }

        private static int Challenge2(string[] matches)
        {
            int finalResult = 0;
            foreach (var match in matches)
            {
                int resultOfMatch = 0;
                List<string> input = match.Split().ToList();
                switch (input[0])
                {
                    case "A":
                        if (input[1] == "X")
                            finalResult += 3;
                        else if (input[1] == "Y")
                            finalResult += 4;
                        else if (input[1] == "Z")
                            finalResult += 8;
                        break;
                    case "B":
                        if (input[1] == "X")
                            finalResult += 1;
                        else if (input[1] == "Y")
                            finalResult += 5;
                        else if (input[1] == "Z")
                            finalResult += 9;
                        break;
                    case "C":
                        if (input[1] == "X")
                            finalResult += 2;
                        else if (input[1] == "Y")
                            finalResult += 6;
                        else if (input[1] == "Z")
                            finalResult += 7;
                        break;
                    default:
                        break;
                }
            }
            return finalResult;
        }
    }
}
