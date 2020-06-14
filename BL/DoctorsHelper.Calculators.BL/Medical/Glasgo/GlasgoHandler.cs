using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.Medical.Glasgo
{
    /// <summary>
    /// Хендлер для получения <see cref="GlasgoResponse"/> из <see cref="GlasgoQuery"/>
    /// Шкала комы Глазго.
    /// </summary>
    public class GlasgoHandler : IQueryHandler<GlasgoQuery, GlasgoResponse>
    {
        public async Task<GlasgoResponse> Handle(GlasgoQuery input)
        {
            var count = input.EyeResponse;
            count += input.MotorResponse;
            count += input.VerbalResponse;

            var result = new GlasgoResponse(count);

            return result;
        }
    }
}