using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorsHelper.ArterialPressure.Data.EFCore.Configurations
{
    public class DiaryRecordConfiguration : IEntityTypeConfiguration<DiaryRecord> 
    {
        public void Configure(EntityTypeBuilder<DiaryRecord> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable(nameof(ArterialPressure) + "DiaryRecords");
            builder.HasOne(x => x.User).WithMany(x => x.DiaryRecords).HasForeignKey(x => x.UserId);
        }
    }
}