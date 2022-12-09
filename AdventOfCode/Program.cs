using AdventOfCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    class Program
    {
        public static List<string> CheckedFolders = new List<string>();
        public static int Score = 0;
        public static string[] lines = File.ReadAllLines(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Input_Simple.txt"));

        static void Main(string[] args)
        {
            Start1();
        }
        
        private static void Start1()
        {
            int score = 0;
            int curStack = 0;
            int stackCount = 0;
            int stackIndex = 0;
            int stackStartIndex = 0;
            Stack<int> stack = new Stack<int>();
            foreach (var line in lines)
            {
                if (int.TryParse(line.Split()[0], out int value))
                {
                    stack.Push(value);
                }
            }
            
            foreach (var line in lines)
            {
                if(line == "$ cd ..")
                {
                    //stackIndex--;
                    //if(stackStartIndex >= stackIndex && stack.Sum() <= 100000)
                    //{

                    //}
                }
                else if(line.Contains("$ cd"))
                {
                    //stackIndex++;
                    //if (stack.Sum() >= 100000)
                    //{
                    //    for (int i = 0; i < stackCount; i++)
                    //    {
                    //        stack.Pop();
                    //    }
                    //    stackCount = 0;
                    //    stackStartIndex = stackIndex;
                    //}
                }
                else if(line.Contains("$ ls"))
                {
                    
                }

                
            }

            stack.ToList().ForEach(x => score += x);

            Console.WriteLine($"Score ist {score}");
            Console.ReadLine();
        }

        private static void Start2()
        {
            List<MyFolder> folders = new List<MyFolder>() { new MyFolder("/", null) };
            MyFolder curFolder = null;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains('$'))
                {
                    if (lines[i].Split()[1].Contains("cd") && lines[i].Split()[2].Contains(".."))
                    {
                        if(curFolder.FolderName == "/")
                        {

                        }
                        else
                        {
                            curFolder = curFolder.ParentFolder;
                        }
                    }
                    else if (lines[i].Split()[1].Contains("cd"))
                    {
                        //var newFolder = new MyFolder(lines[i].Split()[2]);
                        //if(folders.Count != 0)
                        //{
                        //    folders.Last().ParentFolder = newFolder;
                        //}
                        //folders.Add(newFolder);
                        curFolder = folders.Where(x => x.FolderName == lines[i].Split()[2]).FirstOrDefault();
                    }
                    else if (lines[i].Contains("ls"))
                    {
                        //GetFolderContent(i, lines[i]);
                    }
                }
                else if (int.TryParse(lines[i].Split()[0], out int value))
                {
                    folders.Where(x => x == curFolder).ToList().ForEach(c => c.FolderSize += value);
                }
                else if (lines[i].Split()[0] == "dir")
                {
                    folders.Add(new MyFolder(lines[i].Split()[1], curFolder));
                }
            }
            Score = GetScore(folders);
            Console.WriteLine($"Die Lösung ist {Score}");
            Console.ReadLine();
        }

        private static int GetScore(List<MyFolder> folders)
        {
            int score = 0;
            folders.Where(x => x.FolderSize <= 100000).ToList().ForEach(f=> score += f.FolderSize);
            foreach (var folder in folders)
            {
                if(folder.FolderSize <= 100000)
                {

                }
            }
            return score;
        }


    }
}
