
//AIM:Write a program in C# Sharp to create and write some line of text into a file which does not contain a given string in a line.

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stringopContains
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] line;
            string ignore="";
            Console.WriteLine("how many lines you want to enter");
            int n;
            n = Convert.ToInt32(Console.ReadLine());
            line = new string[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("enter the input for line:{0}", i + 1);
                line[i]=Console.ReadLine();
            }
            Console.WriteLine("which word you want to ignore from line");
            ignore=Console.ReadLine();
            if (File.Exists("E://text.text"))
            {
                Console.WriteLine("File already exist");
                File.Delete("E://text.text");
                Console.WriteLine("File deleted");
            }
            using (StreamWriter sw = File.CreateText("E://text.text"))
            {
                for (int i = 0; i < n; i++)
                {
                    if (!(line[i].Contains(ignore)))
                    {
                        sw.WriteLine(line[i]);
                    }
                }
            }
            Console.WriteLine("Content Successfully Written");

            Console.ReadKey();
        }
    }
}
