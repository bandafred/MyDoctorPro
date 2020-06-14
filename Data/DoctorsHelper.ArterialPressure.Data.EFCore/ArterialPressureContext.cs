using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DoctorsHelper.ArterialPressure.Data.EFCore
{
    /// <summary>
    /// Контекст данных
    /// </summary>
    public class ArterialPressureContext : IdentityDbContext<User,Role,string,UserClaim,UserRole,UserLogin,RoleClaim,UserToken>
    {
        public ArterialPressureContext(DbContextOptions<ArterialPressureContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ArterialPressureContext).Assembly);
        }

        public DbSet<UserJwtToken> UserJwtTokens { get; set; }
        public DbSet<UserResetPasswordToken> UserResetPasswordTokens { get; set; }
        public DbSet<DiaryRecord> DiaryRecords { get; set; }
    }
}
