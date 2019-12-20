using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace student_data
{
    class stdcontext:DbContext
    {
        public stdcontext(): base("name=StudentDBConnectionString")
        {

        }
        public DbSet<Student> Std { get; set; }
        public DbSet<Standerd> Standered { get; set; }
    }
}
