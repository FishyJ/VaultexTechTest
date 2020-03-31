using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design.Internal;
using Microsoft.Extensions.Logging;
using VaultexTechTest.Domain;

namespace VaultexTechTest.Data
{
    public class VaultexTechTestContext : DbContext
    {
        private readonly DbContextOptionsBuilder _optionsBuilder;

        public VaultexTechTestContext(DbContextOptions<VaultexTechTestContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking; // useful for readonly...May take out later.
        }

        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
