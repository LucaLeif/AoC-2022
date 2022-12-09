using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = Challenge2(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName,"Real.txt"));
            Console.WriteLine(score);
            Console.ReadLine();
        }

        private static int Challenge1(string path)
        {
            int score = 0;
            string[] linesS = File.ReadAllLines(path);
            List<List<int>> lines = ConvertInput(linesS);
            for (int y = 0; y < lines.Count; y++)
            {

                for (int x = 0; x < lines[y].Count; x++)
                {
                    bool visible = IsVisible(y, x, lines);
                    score += visible ? 1:0;
                }
            }
            return score;
        }

        private static bool IsVisible(int y, int x, List<List<int>> lines)
        {
            if (y == 0 || x == 0 || y == lines.Count-1 || x == lines[y].Count - 1)
            {
                return true;
            }
            bool resultY = CheckX(y, x, lines);
            bool resultX = CheckY(y, x, lines);

            return resultX || resultY;
        }

        private static int Challenge2(string path)
        {
            int score = 0;
            int highscore = 0;
            string[] linesS = File.ReadAllLines(path);
            List<List<int>> lines = ConvertInput(linesS);
            for (int y = 0; y < lines.Count; y++)
            {

                for (int x = 0; x < lines[y].Count; x++)
                {
                    score = CalculateViewingDistance(y, x, lines);
                    if(highscore <= score)
                    {
                        highscore = score;
                    }
                }
            }
            return highscore;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="y">Y Koordinate des zu testenen standort</param>
        /// <param name="x">X Koordinate des zu testenen standort</param>
        /// <param name="lines"></param>
        private static int CalculateViewingDistance(int y, int x, List<List<int>> lines)
        {
            int result = CalculateXY(y, x, lines);

            return result;
        }

        private static int CalculateXY(int y, int x, List<List<int>> lines)
        {
            Stack<int> results = new Stack<int>();
            int curValue = lines[y][x];

            int count = 0;
            for (int l = x-1; l >= 0; l--)
            {
                int value = lines[y][l];
                count++;
                if(value >= curValue)
                {
                    break;
                }
            }
            results.Push(count);

            count = 0;
            for (int r = x+1; r < lines[y].Count; r++)
            {
                int value = lines[y][r];
                count++;
                if(value >= curValue)
                {
                    break;
                }
            }
            results.Push(count);

            count = 0;
            for (int u = y-1; u >= 0; u--)
            {
                int value = lines[u][x];
                count++;
                if (value >= curValue)
                {
                    break;
                }
            }
            results.Push(count);

            count = 0;
            for (int d = y+1; d < lines.Count; d++)
            {
                int value = lines[d][x];
                count++;
                if (value >= curValue)
                {
                    break;
                }
            }
            results.Push(count);

            return CalcResult(results);
        }

        private static int CalcResult(Stack<int> results)
        {
            int result = 1;
            foreach (var res in results)
            {
                result *= res;
            }
            return result;
        }

        private static bool CheckX(int y, int x, List<List<int>> lines)
        {
            Stack<bool> results = new Stack<bool>();
            int curValue = lines[y][x];

            for (int row = 0; row < lines[y].Count; row++)
            {
                int value = lines[y][row];
                if (row == x )
                {
                    if(!results.Contains(false))
                    {
                        return true;
                    }
                    results.Clear();
                }
                else if (value < curValue)
                {
                    results.Push(true);
                }
                else
                {
                    results.Push(false);
                }
            }
            if (!results.Contains(false)) return true;
            return false;
        }

        private static bool CheckY(int y, int x, List<List<int>> lines)
        {
            int curValue = lines[y][x];
            Stack<bool> results = new Stack<bool>();
            for (int column = 0; column < lines.Count; column++)
            {
                int value = lines[column][x];
                if (column == y)
                {
                    if (!results.Contains(false))
                    {
                        return true;
                    }
                    results.Clear();
                }
                else if (value < curValue)
                {
                    results.Push(true);
                }
                else
                {
                    results.Push(false);
                }
            }
            if (!results.Contains(false)) return true;

            return false;
        }

        //if (y - 1 < 0 || lines[y - 1][x] < curValue)
        //{
        //    score++;
        //}
        //if (x - 1 < 0 || lines[y][x - 1] < curValue)
        //{
        //    score++;
        //}
        //if (y + 1 >= lines.Count || lines[y + 1][x] < curValue)
        //{
        //    score++;
        //}
        //if (x + 1 >= lines[y].Count || lines[y][x + 1] < curValue)
        //{
        //    score++;
        //}

        private static List<List<int>> ConvertInput(string[] lines)
        {
            List<List<int>> list = new List<List<int>>();
            List<int> sublist = new List<int>();

            foreach (var line in lines)
            {
                int length = line.Length;
                for (int i = 0; i < length; i++)
                {
                    string subStr = line.Substring(i, 1);
                    sublist.Add(Convert.ToInt32(subStr));
                }
                list.Add(sublist);
                sublist = new List<int>();
            }
            return list;
        }

    }
}
