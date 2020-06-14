using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DoctorsHelper.BL.Core.Interfaces;
using DoctorsHelper.Dictionaries.BL.Order417N.Models;
using DoctorsHelper.Dictionaries.Data.EFCore;
using Microsoft.EntityFrameworkCore;

namespace DoctorsHelper.Dictionaries.BL.Order417N
{
    public class Order417NHandler : IQueryHandler<Order417NQuery,Order417NResponse>
    {
        private readonly DictionariesContext _dictionariesContext;
        private readonly IMapper _mapper;

        public Order417NHandler(DictionariesContext dictionariesContext, IMapper mapper)
        {
            _dictionariesContext = dictionariesContext;
            _mapper = mapper;
        }

        public async Task<Order417NResponse> Handle(Order417NQuery input)
        {
            var records = _dictionariesContext.Order417NRecords.Where(
                record => string.IsNullOrEmpty(input.SearchText) ||
                          record.Point.ToLower().Contains(input.SearchText.ToLower()) ||
                          record.CodeExternal.ToLower().Contains(input.SearchText.ToLower()) ||
                          record.CodeNosology.ToLower().Contains(input.SearchText.ToLower()) ||
                          record.DangerFactor.ToLower().Contains(input.SearchText.ToLower()) ||
                          record.Nosology.ToLower().Contains(input.SearchText.ToLower()));

            return new Order417NResponse
            {
                Records = await records.ProjectTo<Order417NResponseRecord>(_mapper.ConfigurationProvider).ToListAsync()
            };
        }
    }
}
