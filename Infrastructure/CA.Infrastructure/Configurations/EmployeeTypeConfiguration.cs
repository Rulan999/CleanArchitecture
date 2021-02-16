using CA.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.Infrastructure.Configurations
{
    public class EmployeeTypeConfiguration : IEntityTypeConfiguration<EmployeeTypeEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeTypeEntity> builder)
        {
            //builder.ToTable("Employee");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Description).HasMaxLength(50);

            
        }
    }

}
