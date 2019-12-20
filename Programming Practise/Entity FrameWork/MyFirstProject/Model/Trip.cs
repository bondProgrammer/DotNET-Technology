using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
namespace Model
{
    public class Trip
    {
        [Key]
        public Guid Identifier { get; set; }  
        public DateTime StartDate { get; set; }  
        public DateTime EndDate { get; set; }  
        public decimal CostUSD { get; set; }
    }
}
