using System.Collections.Generic;
using DoctorsHelper.Dictionaries.Data.EFCore.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace DoctorsHelper.Dictionaries.Data.EFCore.Configurations
{
    public class Mkb10RecordConfiguration : IEntityTypeConfiguration<Mkb10Record>
    {
        public void Configure(EntityTypeBuilder<Mkb10Record> builder)
        {
            builder.HasData(
                JsonConvert.DeserializeObject<List<Mkb10Record>>(Resources
                    .Mkb10RecordDataJson));
        }
    }
}