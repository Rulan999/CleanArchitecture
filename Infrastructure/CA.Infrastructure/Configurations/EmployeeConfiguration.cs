using CA.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.Infrastructure.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
        {
            //builder.ToTable("EmployeeType");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).HasMaxLength(200);
            builder.HasIndex(a => a.EmployeeType_Id);
        }
    }

}
