using System;
using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.Medical.PotassiumDeficiency
{
    /// <summary>
    /// Расчет дефицита калия в плазме крови.
    /// </summary>
    public class PotassiumDeficiencyResponse : IStringResponse
    {
        public PotassiumDeficiencyResponse(double index)
        {
            Index = index;
        }

        public const string NotPotassiumDeficiencyString = "Дефицита калия нет";
        public const string PotassiumDeficiencyString = "Дефицита калия =";
        public const string PostPotassiumDeficiencyString = "ммоль (мл.)";

        public double Index { get; }

        public string Result => Index <= 0 ? NotPotassiumDeficiencyString : $"{PotassiumDeficiencyString} {Math.Round(Index,3)} {PostPotassiumDeficiencyString}";
    }
}
