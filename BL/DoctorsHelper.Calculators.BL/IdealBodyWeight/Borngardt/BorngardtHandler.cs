using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Interfaces;
using FluentValidation;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.Borngardt
{
    /// <summary>
    /// Хендлер для получения <see cref="BorngardtResponse"/> из <see cref="BorngardtQuery"/>
    /// </summary>
    public class BorngardtHandler : IQueryHandler<BorngardtQuery, BorngardtResponse>
    {
        public async Task<BorngardtResponse> Handle(BorngardtQuery input)
        {
            await new BorngardtQueryValidator().ValidateAndThrowAsync(input);

            return new BorngardtResponse(input.Height * input.ChestСircumference / 240);
        }
    }
}
