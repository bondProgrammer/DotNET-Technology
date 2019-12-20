using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using Model;

namespace DataAccess
{
    public class BreakAwayContext:DbContext
    {
        public BreakAwayContext() : base("name=SourceDbConnection") { }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Lodging> Lodgings { get; set; }
    }
}
