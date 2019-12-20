using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Model
{
    public class Destination 
    {
        protected void OnModelCreating(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Destination>().Property(d=>d.Name).IsRequired();
            modelbuilder.Entity<Destination>().Property(d=>d.Description).HasMaxLength(500);
            modelbuilder.Entity<Destination>().Property(d=>d.photo).HasColumnType("image");
            modelbuilder.Entity<Lodging>().Property(d=>d.Name).HasMaxLength(500).IsRequired();
        }
        public int DestinationId { get; set; }

        public string Name { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
       
        public byte[] photo { get; set; }
        public List<Lodging> Lodgings { get; set; }
    }
}
