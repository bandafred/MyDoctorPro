using Microsoft.EntityFrameworkCore;

namespace DoctorsHelper.Dictionaries.Data.EFCore
{
    public class DictionariesContext : DbContext
    {
        public DictionariesContext(DbContextOptions<DictionariesContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(DictionariesContext).Assembly);
        }

        public DbSet<GeneralMedicalContraindication> GeneralMedicalContraindications { get; set; }
        public DbSet<Mkb10Record> Mkb10Records { get; set; }
        public DbSet<Order302NRecord> Order302NRecords { get; set; }
        public DbSet<Order417NRecord> Order417NRecords{ get; set; }
    }
}
