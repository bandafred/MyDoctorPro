using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorsHelper.ArterialPressure.Data.EFCore.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role> 
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(nameof(ArterialPressure) + "Roles");
        }
    }
}