using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity;
using DataAccess;
namespace BreakAwayConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<BreakAwayContext>());
            InsertDestination();
        }
        private static void InsertDestination()
        {
            var destination = new Destination
            {
                Country="India",
                Description="The Best Country in World",
                Name="Pawan"
            };
            var lodging = new Lodging
            {
                Name="sharma lodge",
                Owner="kmy",
                IsResort=false
            };
            using(var ctx=new BreakAwayContext())
            {
                ctx.Destinations.Add(destination);
                ctx.Lodgings.Add(lodging);
                ctx.SaveChanges();
            }
        }
    }
}
