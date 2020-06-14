using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.Medical.ContrastInducedNephropathy
{
    /// <summary>
    /// Хендлер для получения <see cref="ContrastInducedNephropathyResponse"/> из <see cref="ContrastInducedNephropathyQuery"/>
    /// Вероятность развития контраст индуцированной нефропатии.
    /// </summary>
    public class ContrastInducedNephropathyHandler : IQueryHandler<ContrastInducedNephropathyQuery, ContrastInducedNephropathyResponse>
    {
        public async Task<ContrastInducedNephropathyResponse> Handle(ContrastInducedNephropathyQuery input)
        {
            var count = 0;

            if (input.IsAnemya) count += 3;
            if (input.IsBigCreatinin) count += 4;
            if (input.IsDiabetes) count += 3;
            if (input.IsHypotonia) count += 5;
            if (input.IsOldAge) count += 4;
            if (input.IsNYHA) count += 5;
            if (input.IsVABK) count += 5;

            count += input.VolumeContrast;
            count += input.SpeedKF;

            var result = new ContrastInducedNephropathyResponse(count);

            return result;
        }
    }
}