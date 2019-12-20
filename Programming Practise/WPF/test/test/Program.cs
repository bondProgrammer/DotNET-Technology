using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
           byte[] bt =  File.ReadAllBytes(@"D:\t.pdf");
           Console.ReadKey();

        }
    }
}
