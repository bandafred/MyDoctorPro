using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorsHelper.ArterialPressure.Data.EFCore.Configurations
{
    public class UserJwtTokenConfiguration : IEntityTypeConfiguration<UserJwtToken>
    {
        public void Configure(EntityTypeBuilder<UserJwtToken> builder)
        {
            builder.ToTable(nameof(ArterialPressure) + "UserJwtTokens");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User).WithMany(x => x.UserJwtTokens).HasForeignKey(x => x.UserId);
        }
    }
}