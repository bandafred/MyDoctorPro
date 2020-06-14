using System.Collections.Generic;
using DoctorsHelper.Dictionaries.Data.EFCore.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace DoctorsHelper.Dictionaries.Data.EFCore.Configurations
{
    public class Order417NRecordConfiguration : IEntityTypeConfiguration<Order417NRecord>
    {
        public void Configure(EntityTypeBuilder<Order417NRecord> builder)
        {
            builder.HasData(
                JsonConvert.DeserializeObject<List<Order417NRecord>>(Resources
                    .Order417NRecordDataJson));
        }
    }
}