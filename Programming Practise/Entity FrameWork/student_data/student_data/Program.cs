using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_data
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertDestination();
        }
        private static void InsertDestination()
        {
            var stdid = new Standerd { StdName = "sixth" };
            var student = new Student()
            {
                Name = "Manisha",
                Stand = stdid,
            };
            using (var ctx = new stdcontext())
            {

                ctx.Std.Add(student);
                ctx.SaveChanges();

            }
        }
    }
}
