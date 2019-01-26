using MicWay.Driver.Library.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MicWay.Driver.Library.Repository
{
    public class DriverContext : DbContext
    {
        public DriverContext() : base("Driver")
        {
        }

        public DbSet<Models.Driver> Driver { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
