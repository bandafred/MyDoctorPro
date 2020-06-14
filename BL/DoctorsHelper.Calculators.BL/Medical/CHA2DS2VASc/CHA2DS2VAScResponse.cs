using System.Collections.Generic;
using Newtonsoft.Json;

namespace DoctorsHelper.Calculators.BL.Medical.CHA2DS2VASc
{
    /// <summary>
    /// Результат шкалы CHA2DS2VASc.
    /// </summary>
    public class CHA2DS2VAScResponse
    {
        public const string ResultString = "Ожидаемая частота инсультов за год - ";
        public const string Recomendation = "Рекомендованная антитромботическая терапия - ";
        public const string Note = "Примечание: при механических протезах клапанов сердца целевое МНО может быть выше.";
        public const string IndexZero = "аспирин 75-325мг в сутки или отсутствие антитромботической терапии(предпочтительно)";
        public const string IndexOne = "пероральный антикоагулянт (предпочтительно) или аспирин 75-325мг в сутки";
        public const string IndexMore = "антагонист витамина К (например, варфарин) с целевым МНО 2,5 (2,0-3,0)";

        [JsonIgnore]
        public double Index { get; }

        [JsonIgnore]
        public double Resultate =>
            Index switch
                {
                0 => 0,
                1 => 1.3,
                2 => 2.2,
                3 => 3.2,
                4 => 4,
                5 => 6.7,
                6 => 9.8,
                7 => 9.6,
                8 => 6.7,
                9 => 15.2,
                _ => 0
                };

        public CHA2DS2VAScResponse(int index)
        {
            Index = index;
        }

        public List<string> Result => new List<string>
        {
            $"{ResultString} {Resultate}%",
            $"{Recomendation} {GetRecomendation}",
            Index > 1 ? Note : null
        };
        
        private string GetRecomendation
        {
            get
            {
                if (Index == 0) return IndexZero;
                if (Index == 1) return IndexOne;
                if (Index > 1) return IndexMore;
                return null;
            }
        }
    }
}
