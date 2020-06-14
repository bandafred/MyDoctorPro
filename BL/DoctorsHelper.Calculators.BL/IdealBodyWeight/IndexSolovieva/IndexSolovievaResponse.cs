using System;
using DoctorsHelper.BL.Core.Interfaces;
using Newtonsoft.Json;

namespace DoctorsHelper.Calculators.BL.IdealBodyWeight.IndexSolovieva
{
    /// <summary>
    /// Результат Индекса Соловьева.
    /// </summary>
    public class IndexSolovievaResponse : IStringResponse
    {
        public IndexSolovievaResponse(IndexSolovievaResultsEnum indexSolovieva)
        {
            IndexSolovieva = indexSolovieva;
        }

        public const string AsthenicResponseString = "Астенический тип телосложения";
        public const string NormaResponseString = "Нормостенический тип телосложения";
        public const string HyperResponseString = "Гиперстенический тип телосложения";

        public const string OutofRangeErrorString = "Неподдерживаемое значение индекса Соловьева";

        [JsonIgnore]
        public IndexSolovievaResultsEnum IndexSolovieva { get; }

        public string Result =>
            IndexSolovieva switch
            {
                IndexSolovievaResultsEnum.Asthenic => AsthenicResponseString,
                IndexSolovievaResultsEnum.Norma => NormaResponseString,
                IndexSolovievaResultsEnum.Hyper => HyperResponseString,
                _ => throw new ArgumentOutOfRangeException(OutofRangeErrorString)
            };
    }
}
