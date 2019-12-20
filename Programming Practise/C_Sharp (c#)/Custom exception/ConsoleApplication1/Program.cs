using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class invalidDivideZero : Exception
    {
        public invalidDivideZero(string message)
            :base (message)
        {
        }
    };
    class Program
    {
        public void valid()
        {
            int b = 0;
            if (b == 0)
            {
                throw new invalidDivideZero("dvide by zero exception");
            }

        }
        static void Main(string[] args)
        {

            try
            {
                Program p = new Program();
               p.valid();
            }
            catch (invalidDivideZero message)
            {
                Console.WriteLine(message);
            }

            finally
            {
                Console.WriteLine("THANK YOU");
            }

            Console.WriteLine("Rest of th statement");


        }
    }
}
