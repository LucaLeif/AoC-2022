using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "input.txt");
            int result = Challenge1(path);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        private static int Challenge2(string path)
        {
            string[] lines = File.ReadAllLines(path);
            return 0;
        }

        private static int Challenge1(string path)
        {
            string[] lines = File.ReadAllLines(path);
            int result = CountPositions(lines);
            return result;
        }

        private static int CountPositions(string[] lines)
        {
#if DEBUG
            //lines = new string[] { "L 1" };
#endif
            List<string> marks = new List<string>() { "0,0" };

            // Koordinaten von Head und Tail
            int yOfHead = 0;
            int xOfHead = 0;

            int yOfTail = 0;
            int xOfTail = 0;

            foreach (var line in lines)
            {
                string direction = line.Split()[0];
                int times = Convert.ToInt32(line.Split()[1]);
                for (int i = 0; i < times; i++)
                {
                    switch (direction)
                    {
                        case "U":
                            yOfHead++;
                            break;
                        case "D":
                            yOfHead--;
                            break;
                        case "R":
                            xOfHead++;
                            break;
                        case "L":
                            xOfHead--;
                            break;
                        default:
                            break;
                    }
                    if(TailJumpsTohead(ref xOfHead,ref yOfHead,ref xOfTail,ref yOfTail, direction))
                    {
                        string coordinates = ConvertCoordinates(xOfTail,yOfTail);
                        if (!marks.Contains(coordinates))
                        {
                            marks.Add(coordinates);
                        }
                    }

                }
            }
            return marks.Count;
        }

        private static bool TailJumpsTohead(ref int xHead,ref int yHead,ref int xTail,ref int yTail,string direction)
        {
            int differenceX = Math.Abs(xHead - xTail);
            int differenceY = Math.Abs(yHead - yTail);

            int additional = 1;

            if (differenceX > 1 || differenceY > 1)
            {
                switch (direction)
                {
                    case "U":
                        yTail = yHead - additional;
                        xTail = xHead;
                        break;          
                    case "D":           
                        yTail = yHead + additional;
                        xTail = xHead;
                        break;          
                    case "R":           
                        xTail = xHead - additional;
                        yTail = yHead;
                        break;          
                    case "L":           
                        xTail = xHead + additional;
                        yTail = yHead;
                        break;
                    default:
                        break;
                }
                return true;
            }
            return false;
        }

        private static string ConvertCoordinates(int x, int y)
        {
            string result = $"{x},{y}";
            return result;
        }
    }
}
