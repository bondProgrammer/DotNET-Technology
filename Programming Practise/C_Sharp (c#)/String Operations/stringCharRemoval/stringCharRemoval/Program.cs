//AIM:Write a C# program remove specified a character from a non-empty string using index of a character.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stringCharRemoval
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" ;
            string s2 = s1.Remove(4, 1);  //E Removed
            Console.WriteLine(s2);    //ABCDFGHIJKLMNOPQRSTUVWXYZ
            s2 = s1.Remove(1, 3);   // B,C,D Removed
            Console.WriteLine(s2);   //AEFGHIJKLMNOPQRSTUVWXYZ
        }
    }
}
