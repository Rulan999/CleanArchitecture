using CA.Infrastructure;
using CA.Infrastructure.Configurations;
using CA.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace CA.Infrastructure
{
    public class BaseDBContext : DbContext
    {
        public BaseDBContext(DbContextOptions<BaseDBContext> options)
            :base(options)
        {
           
        }
        public DbSet<EmployeeEntity> EmployeeEntities { get; set; }
        public DbSet<EmployeeTypeEntity> EmployeeTypeEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
           modelBuilder.ApplyConfiguration(new EmployeeTypeConfiguration());
           base.OnModelCreating(modelBuilder);
        }
    }
}
