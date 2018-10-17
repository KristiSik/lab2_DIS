using MVCProject.Models;
using System.Data.Entity;

namespace MVCProject.EF
{
    public class TransportsDbContext : DbContext
    {
        public TransportsDbContext() : base("name=TransportsDbConnectionString")
        {
            Database.SetInitializer(new TransportsDbInitializer());
        }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<TransportCompany> TransportCompanies { get; set; }
        public DbSet<Transportation> Transportations { get; set; }
    }
}
