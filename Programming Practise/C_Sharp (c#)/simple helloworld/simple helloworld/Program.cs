using System;
namespace simplehelloworld
{
    public class Program
    {
        unsafe public static void Main(string[] args)
        {
            System.Console.WriteLine("helloworld");
            
            {
                int* a;
                int b = 10;
                a = &b;
                Console.WriteLine(*a);


            }



            // Convert string to number.
            string text = "500";
            int num = int.Parse(Console.ReadLine());
            num = num + 100;
            Console.WriteLine(num);


            Console.Write("Box");
            Console.Write("Table");
            Console.Write("chair");
            Console.WriteLine();
            Console.WriteLine("desk");

            Console.WriteLine(" READ ");
            int i = Console.Read();//it always return int value.///((( WRONG OUTPUT))))
            Console.WriteLine(i);
            //Console.ReadLine();
            /*{
          Console.WriteLine(" READ line string bute enter  int");
            
          string s = Console.ReadLine();
           Console.WriteLine(s);

          //string s = Console.ReadLine();//it always return string value.
          //Console.WriteLine(s);

            
          Console.WriteLine(" READline with convert ");
          int num = Convert.ToInt32(Console.ReadLine());
          //Console.WriteLine(num);
            }
             * 
             */
            //((( CODE UNKNOW)))
        }
    }

}