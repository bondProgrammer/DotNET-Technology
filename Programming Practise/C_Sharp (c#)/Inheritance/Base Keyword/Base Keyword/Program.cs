using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Keyword
{
    public class A
    {
        public A(int a, int b)
        {


        }
        private A(int a)
        {

        }
    };
     public class B : A
    {
         public B()
         {

         }
    };
    public class C : B
    {
       
    };
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
