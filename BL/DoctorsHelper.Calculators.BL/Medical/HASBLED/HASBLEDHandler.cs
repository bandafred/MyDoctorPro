using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.Medical.HASBLED
{
    /// <summary>
    /// Хендлер для получения <see cref="HASBLEDResponse"/> из <see cref="HASBLEDQuery"/>
    /// Шкала HAS-BLED.
    /// </summary>
    public class HASBLEDHandler : IQueryHandler<HASBLEDQuery, HASBLEDResponse>
    {
        public async Task<HASBLEDResponse> Handle(HASBLEDQuery input)
        {
            var count = 0;

            if (input.Alcohol) count++;
            if (input.Hypertension) count++;
            if (input.Bleeding) count++;
            if (input.Insult) count++;
            if (input.CreatinineIncreased) count++;
            if (input.AntiplateletAgents) count++;
            if (input.Mno) count++;
            if (input.OldAge) count++;
            if (input.Transaminase) count++;

            var result = new HASBLEDResponse(count);

            return result;
        }
    }
}