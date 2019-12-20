using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_data
{
    class Student
    {
        public int StudentID { get; set; }
        [Required]
        
        public string Name { get; set; }
        
        public int Height { get; set; }
        public int Weight { get; set; }

        public Standerd Stand { get; set; }
    }
    class Standerd
    {
        public int StanderdId { get; set; }
        [Column("Standered")]
        public string StdName { get; set; }
        public List<Student> Student { get; set; }
    } 
}
