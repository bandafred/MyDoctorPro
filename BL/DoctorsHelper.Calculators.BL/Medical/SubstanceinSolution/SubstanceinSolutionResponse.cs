using System.Collections.Generic;
using Newtonsoft.Json;

namespace DoctorsHelper.Calculators.BL.Medical.SubstanceinSolution
{
    /// <summary>
    /// Результат расчет содержания вещества в растворе (пересчет процентов в миллиграммы)..
    /// </summary>
    public class SubstanceinSolutionResponse 
    {
        [JsonIgnore] public double Recount { get; }

        public SubstanceinSolutionResponse(double recount)
        {
            Recount = recount;
        }

        public List<string> Result {
            get
            {
                var result = new List<string>
                {
                    $"{Recount} г.",
                    $"{Recount * 1000} мг.",
                    $"{Recount * 1000000} мкг.",

                };
             
                return result;
            }
        }
}
}
