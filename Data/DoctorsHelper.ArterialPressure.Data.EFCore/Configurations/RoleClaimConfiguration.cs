using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorsHelper.ArterialPressure.Data.EFCore.Configurations
{
    public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.ToTable(nameof(ArterialPressure) + "RoleClaims");
            builder.HasOne(x => x.Role).WithMany(x => x.RoleClaims).HasForeignKey(x => x.RoleId);
        }
    }
}