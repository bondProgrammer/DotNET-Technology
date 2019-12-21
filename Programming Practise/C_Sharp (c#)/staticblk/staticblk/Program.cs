using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Advance
    {
        static Advance()
        {
            Console.WriteLine("Advance Static Constructor");
        }
    }
    class Program:Advance
    {
        static Program()
        {
            Console.WriteLine("static Program sonstructor");
        }
        static void Main(string[] args)
        {
            Advance a = new Advance();
            //Program p = new Program();
            Console.WriteLine("in main");
            Console.ReadLine();
        }
    }
}
