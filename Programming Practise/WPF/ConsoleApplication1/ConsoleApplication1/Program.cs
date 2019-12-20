using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int min = 0;
            int max = 99;
            int count = 100;
            int res = 0 ;
           while (count != 1)
           {
               Console.WriteLine("Is your no greater than {0}" , ((min+max )/2));
               res =(min+max )/2;
               char ch1 = Convert.ToChar(Console.ReadLine());
               if (ch1 == 'y')
               {
                   int temp = min;
                   min = (min + max) / 2;
                   count = min - temp;
                   count--;
               }
               else if(ch1 == 'o')
               {
                   
                   Console.WriteLine("your no is {0}", res);
               }
               else
               {
                   int temp = max;
                   max = (min + max) / 2;
                   count = max - temp;
                   count--;
               }

           }
           Console.WriteLine(count);
           Console.WriteLine(res+2);



        }
    }
}
