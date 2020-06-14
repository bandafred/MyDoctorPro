using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorsHelper.ArterialPressure.Data.EFCore.Configurations
{
    public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            builder.ToTable(nameof(ArterialPressure) + "UserClaims");
            builder.HasOne(x => x.User).WithMany(x => x.UserClaims).HasForeignKey(x => x.UserId);
        }
    }
}