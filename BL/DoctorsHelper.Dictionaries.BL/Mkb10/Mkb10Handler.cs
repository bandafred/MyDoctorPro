using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DoctorsHelper.BL.Core.Interfaces;
using DoctorsHelper.Dictionaries.BL.Mkb10.Models;
using DoctorsHelper.Dictionaries.Data.EFCore;
using Microsoft.EntityFrameworkCore;

namespace DoctorsHelper.Dictionaries.BL.Mkb10
{
    public class Mkb10Handler : IQueryHandler<Mkb10Query,Mkb10Response>
    {
        private readonly DictionariesContext _dictionariesContext;
        private readonly IMapper _mapper;

        public Mkb10Handler(DictionariesContext dictionariesContext, IMapper mapper)
        {
            _dictionariesContext = dictionariesContext;
            _mapper = mapper;
        }

        public async Task<Mkb10Response> Handle(Mkb10Query input)
        {
            var records = _dictionariesContext.Mkb10Records.Where(
                record => string.IsNullOrEmpty(input.SearchText) ||
                          record.Code.ToLower().Contains(input.SearchText.ToLower()) ||
                          record.Name.ToLower().Contains(input.SearchText.ToLower()));

            return new Mkb10Response
            {
                Records = await records.Skip(input.SkipCount).Take(input.TakeCount).ProjectTo<Mkb10ResponseRecord>(_mapper.ConfigurationProvider).ToListAsync(),
                TotalCount = await records.CountAsync()
            };
        }
    }
}
