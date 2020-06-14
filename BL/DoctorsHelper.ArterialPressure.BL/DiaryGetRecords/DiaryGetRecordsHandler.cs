using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DoctorsHelper.ArterialPressure.BL.DiaryGetRecords.Models;
using DoctorsHelper.ArterialPressure.Data;
using DoctorsHelper.ArterialPressure.Data.EFCore;
using DoctorsHelper.BL.Core.Exceptions;
using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.BL.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DoctorsHelper.ArterialPressure.BL.DiaryGetRecords
{
    public class DiaryGetRecordsHandler : IQueryHandler<DiaryGetRecordsQuery, DiaryGetRecordsResponse>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly ArterialPressureContext _arterialPressureContext;

        public DiaryGetRecordsHandler(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager,
            IMapper mapper, ArterialPressureContext arterialPressureContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _mapper = mapper;
            _arterialPressureContext = arterialPressureContext;
        }

        public async Task<DiaryGetRecordsResponse> Handle(DiaryGetRecordsQuery input)
        {
            var tokenString = _httpContextAccessor.HttpContext.GetJwtToken();
            var user = await _userManager.Users.FirstOrDefaultAsync(u =>
                u.UserJwtTokens.Any(jwtToken => jwtToken.Token == tokenString));
            if (user == null)
                throw new NotFoundException("Пользователь не найден");

            var diaryRecords = await _arterialPressureContext.DiaryRecords.Where(record =>
                    record.UserId == user.Id &&
                    (input.FromDate == null || record.Date >= input.FromDate) &&
                    (input.ToDate == null || record.Date <= input.ToDate))
                .ProjectTo<DiaryGetRecordsResponseRecord>(_mapper.ConfigurationProvider).ToListAsync();
            
            return new DiaryGetRecordsResponse {Records = diaryRecords};
        }
    }
}