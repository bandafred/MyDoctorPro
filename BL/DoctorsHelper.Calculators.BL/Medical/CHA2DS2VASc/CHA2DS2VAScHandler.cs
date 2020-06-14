using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.Medical.CHA2DS2VASc
{
    /// <summary>
    /// Хендлер для получения <see cref="CHA2DS2VAScResponse"/> из <see cref="CHA2DS2VAScQuery"/>
    /// Шкала CHA2DS2VASc для оценки риска тромбоэмболических осложнений у больных с фибрилляцией/трепетанием предсердий.
    /// </summary>
    public class CHA2DS2VAScHandler : IQueryHandler<CHA2DS2VAScQuery, CHA2DS2VAScResponse>
    {
        public async Task<CHA2DS2VAScResponse> Handle(CHA2DS2VAScQuery input)
        {
            var count = 0;

            if (input.IsArterialHypertension) count++;
            if (input.IsMyocardialInfarction) count++;
            if (input.IsInsult) count += 2;
            if (input.IsOld65) count++;
            if (input.IsOld75) count = input.IsOld65 ? count++ : count + 2;
            if (input.IsDiabetes) count++;
            if (input.IsHeartFailure) count++;
            if (input.IsWomen) count++;

            var result = new CHA2DS2VAScResponse(count);

            return result;
        }

       
    }
}