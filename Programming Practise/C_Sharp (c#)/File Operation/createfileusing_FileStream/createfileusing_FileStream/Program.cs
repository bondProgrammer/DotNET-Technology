using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace createfileusing_FileStream
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (FileStream fs = new FileStream("E:\\text.text", FileMode.OpenOrCreate))
                {
                    Console.WriteLine("file successfully created");
                }
                string filename = "E:\\text.text";
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                    Console.WriteLine("file succesfully deleted");
                }
                else
                    Console.WriteLine("File do not exits");
                Console.ReadKey();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
