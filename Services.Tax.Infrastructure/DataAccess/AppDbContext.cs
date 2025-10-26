using Microsoft.EntityFrameworkCore;
using Services.Tax.Domain.DataAccess;

namespace Services.Tax.Infrastructure.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Period> Period { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Period>().HasData(
                new Period { Id = 1, Name = "PerYear", SplitValue = 1 },
                new Period { Id = 2, Name = "PerHalfYear", SplitValue = 2 },
                new Period { Id = 3, Name = "PerQuarter", SplitValue = 4 },
                new Period { Id = 4, Name = "PerMonth", SplitValue = 12 });
        }
    }
}
