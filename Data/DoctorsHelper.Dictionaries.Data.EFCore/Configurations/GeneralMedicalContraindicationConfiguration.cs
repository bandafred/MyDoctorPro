using System.Collections.Generic;
using DoctorsHelper.Dictionaries.Data.EFCore.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace DoctorsHelper.Dictionaries.Data.EFCore.Configurations
{
    public class GeneralMedicalContraindicationConfiguration : IEntityTypeConfiguration<GeneralMedicalContraindication>
    {
        public void Configure(EntityTypeBuilder<GeneralMedicalContraindication> builder)
        {
            builder.HasData(
                JsonConvert.DeserializeObject<List<GeneralMedicalContraindication>>(Resources
                    .GeneralMedicalContraindicationDataJson));
        }
    }
}
