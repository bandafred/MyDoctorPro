using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DoctorsHelper.ArterialPressure.Data;
using DoctorsHelper.ArterialPressure.Data.EFCore;
using DoctorsHelper.BL.Core.Exceptions;
using DoctorsHelper.BL.Core.Extensions;
using DoctorsHelper.BL.Core.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DoctorsHelper.ArterialPressure.BL.DiaryAddRecord
{
    public class DiaryAddRecordHandler : ICommandHandler<DiaryAddRecordCommand, DiaryAddRecordResponse>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly ArterialPressureContext _arterialPressureContext;

        public DiaryAddRecordHandler(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager,
            IMapper mapper, ArterialPressureContext arterialPressureContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _mapper = mapper;
            _arterialPressureContext = arterialPressureContext;
        }

        public async Task<DiaryAddRecordResponse> Handle(DiaryAddRecordCommand input)
        {
            await new DiaryAddRecordCommandValidator().ValidateAndThrowAsync(input);

            var tokenString = _httpContextAccessor.HttpContext.GetJwtToken();
            var user = await _userManager.Users.FirstOrDefaultAsync(u =>
                u.UserJwtTokens.Any(jwtToken => jwtToken.Token == tokenString));
            if (user == null)
                throw new NotFoundException("Пользователь не найден");

            var diaryRecord = await _arterialPressureContext.DiaryRecords.FirstOrDefaultAsync(record =>
                record.UserId == user.Id && record.Date == input.Date && record.IsMorning == input.IsMorning);
            if (diaryRecord != null)
            {
                diaryRecord = _mapper.Map(input, diaryRecord);
                _arterialPressureContext.DiaryRecords.Update(diaryRecord);
            }
            else
            {
                diaryRecord = _mapper.Map<DiaryRecord>(input);
                diaryRecord.UserId = user.Id;
                await _arterialPressureContext.AddAsync(diaryRecord);
            }
            
            await _arterialPressureContext.SaveChangesAsync();

            return new DiaryAddRecordResponse();
        }
    }
}