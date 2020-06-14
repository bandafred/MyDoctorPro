using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DoctorsHelper.BL.Core.Interfaces;
using DoctorsHelper.Dictionaries.BL.GeneralMedicalContraindications.Models;
using DoctorsHelper.Dictionaries.Data.EFCore;
using Microsoft.EntityFrameworkCore;

namespace DoctorsHelper.Dictionaries.BL.GeneralMedicalContraindications
{
    public class GeneralMedicalContraindicationHandler : IQueryHandler<GeneralMedicalContraindicationQuery,GeneralMedicalContraindicationResponse>
    {
        private readonly DictionariesContext _dictionariesContext;
        private readonly IMapper _mapper;

        public GeneralMedicalContraindicationHandler(DictionariesContext dictionariesContext, IMapper mapper)
        {
            _dictionariesContext = dictionariesContext;
            _mapper = mapper;
        }

        public async Task<GeneralMedicalContraindicationResponse> Handle(GeneralMedicalContraindicationQuery input)
        {
            var records = _dictionariesContext.GeneralMedicalContraindications.Where(
                record => string.IsNullOrEmpty(input.SearchText) ||
                          record.Pathology.ToLower().Contains(input.SearchText.ToLower()));

            return new GeneralMedicalContraindicationResponse
            {
                Records = await records.ProjectTo<GeneralMedicalContraindicationResponseRecord>(_mapper.ConfigurationProvider).ToListAsync()
            };
        }
    }
}
