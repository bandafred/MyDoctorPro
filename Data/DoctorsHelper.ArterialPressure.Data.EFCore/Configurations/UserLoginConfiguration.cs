using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorsHelper.ArterialPressure.Data.EFCore.Configurations
{
    public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.ToTable(nameof(ArterialPressure) + "UserLogins");
            builder.HasOne(x => x.User).WithMany(x => x.UserLogins).HasForeignKey(x => x.UserId);
        }
    }
}