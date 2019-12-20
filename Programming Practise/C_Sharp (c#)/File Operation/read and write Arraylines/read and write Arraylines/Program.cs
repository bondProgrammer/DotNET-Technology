//Aim:Write a program in C# Sharp to create a file and write an array of strings to the file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace read_and_write_Arraylines
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr;
            Console.WriteLine("enter how many no of line you want to write");
            int n;
            n = Convert.ToInt32(Console.ReadLine());
            arr = new string[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Input for line:{0}", i + 1);
                arr[i] = Console.ReadLine();
            }
            System.IO.File.WriteAllLines("E://text.text", arr);
            using (System.IO.StreamReader sr = System.IO.File.OpenText("E://text.text"))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
            Console.WriteLine("<...................>");
            Console.WriteLine("thankyou");

        }
    }
}
