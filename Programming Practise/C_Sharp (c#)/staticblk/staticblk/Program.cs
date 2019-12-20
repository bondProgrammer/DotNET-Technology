using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staticblk
{
    static class Program
    {
        static Program()
        {
            Console.WriteLine("static sonstructor");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("in main");
        }
    }
}
