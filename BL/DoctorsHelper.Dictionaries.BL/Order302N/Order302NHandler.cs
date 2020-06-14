using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DoctorsHelper.BL.Core.Interfaces;
using DoctorsHelper.Dictionaries.BL.Order302N.Models;
using DoctorsHelper.Dictionaries.Data.EFCore;
using Microsoft.EntityFrameworkCore;

namespace DoctorsHelper.Dictionaries.BL.Order302N
{
    public class Order302NHandler : IQueryHandler<Order302NQuery,Order302NResponse>
    {
        private readonly DictionariesContext _dictionariesContext;
        private readonly IMapper _mapper;

        public Order302NHandler(DictionariesContext dictionariesContext, IMapper mapper)
        {
            _dictionariesContext = dictionariesContext;
            _mapper = mapper;
        }

        public async Task<Order302NResponse> Handle(Order302NQuery input)
        {
            var records = _dictionariesContext.Order302NRecords.Where(
                record => string.IsNullOrEmpty(input.SearchText) ||
                          record.Name.ToLower().Contains(input.SearchText.ToLower()) ||
                          record.AdditionalMedicalContraindications.ToLower().Contains(input.SearchText.ToLower()) ||
                          record.InspectionFrequency.ToLower().Contains(input.SearchText.ToLower()) ||
                          record.Point.ToLower().Contains(input.SearchText.ToLower()));

            return new Order302NResponse
            {
                Records = await records.ProjectTo<Order302NResponseRecord>(_mapper.ConfigurationProvider).ToListAsync()
            };
        }
    }
}
