using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorsHelper.ArterialPressure.Data.EFCore.Configurations
{
    public class UserResetPasswordTokenConfiguration : IEntityTypeConfiguration<UserResetPasswordToken>
    {
        public void Configure(EntityTypeBuilder<UserResetPasswordToken> builder)
        {
            builder.ToTable(nameof(ArterialPressure) + "UserResetPasswordTokens");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserPasswordResetTokens)
                .HasForeignKey(x => x.UserId);
        }
    }
}