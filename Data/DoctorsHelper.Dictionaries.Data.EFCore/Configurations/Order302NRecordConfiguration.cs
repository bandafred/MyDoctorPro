using System.Collections.Generic;
using DoctorsHelper.Dictionaries.Data.EFCore.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace DoctorsHelper.Dictionaries.Data.EFCore.Configurations
{
    public class Order302NRecordConfiguration : IEntityTypeConfiguration<Order302NRecord>
    {
        public void Configure(EntityTypeBuilder<Order302NRecord> builder)
        {
            builder.HasData(
                JsonConvert.DeserializeObject<List<Order302NRecord>>(Resources
                    .Order302NRecordDataJson));
        }
    }
}