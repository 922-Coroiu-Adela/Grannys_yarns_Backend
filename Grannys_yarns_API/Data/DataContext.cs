using Grannys_yarns_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Grannys_yarns_API.Data
{
    public class DataContext: DbContext
    {
        public DbSet<Yarn> Yarns { get; set; }
        public DbSet<Distributor> Distributors { get; set; }

        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Distributor>()
                .HasMany(d => d.yarns)
                .WithOne(y => y.distributor)
                .HasForeignKey(y => y.distributorId);
        }

        
    }
}
