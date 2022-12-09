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
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "mock.txt");
            int result = Challenge1(path);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        private static int Challenge1(string path)
        {
            string[] lines = File.ReadAllLines(path);

            return 0;
        }
    }
}
