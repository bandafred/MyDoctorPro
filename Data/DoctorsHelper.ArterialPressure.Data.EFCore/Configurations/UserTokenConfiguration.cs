using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorsHelper.ArterialPressure.Data.EFCore.Configurations
{
    public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.ToTable(nameof(ArterialPressure) + "UserTokens");
            builder.HasOne(x => x.User).WithMany(x => x.UserTokens).HasForeignKey(x => x.UserId);
        }
    }
}