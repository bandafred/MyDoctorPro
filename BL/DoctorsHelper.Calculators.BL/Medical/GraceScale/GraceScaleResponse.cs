using System.Collections.Generic;
using DoctorsHelper.BL.Core.Interfaces;
using Newtonsoft.Json;

namespace DoctorsHelper.Calculators.BL.Medical.GraceScale
{
    /// <Indexry>
    /// Результат расчета шкалы GRACE.
    /// </Indexry>
    public class GraceScaleResponse : IListStringResponse
    {
        public GraceScaleResponse(int index)
        {
            Index = index;
        }

        [JsonIgnore]
        public int Index { get; }

        public List<string> Result =>
            new List<string>
            {
                $"{Index} балл{(Index % 10 == 1 ? null: Index % 10 > 1 && Index % 10 < 5 ? "а" : "ов")}",
                $"ОКС с подъемом ST: 6-ти месячная летальность: {Letal(Index, true, false)}, риск: {Risk(Index, true, false)}",
                $"Внутригоспитальная летальность: {Letal(Index, true, true)}, риск: {Risk(Index, true, true)}",
                $"ОКС без подъема ST: 6-ти месячная летальность: {Letal(Index, true, true)}, риск: {Risk(Index, true, true)}",
                $"Внутригоспитальная летальность: {Letal(Index, false, true)}, риск: {Risk(Index, false, true)}"
            };

        private string Risk(int index, bool st, bool gosp)
        {
            if (st)
            {
                if (gosp)
                {
                    if (index < 126) return "низкий";
                    if (index >= 126 & index <= 154) return "средний";
                    return "высокий";
                }
                else
                {
                    if (index < 100) return "низкий";
                    if (index >= 100 & index <= 127) return "средний";
                    return "высокий";
                }
            }
            else
            {
                if (gosp)
                {
                    if (index < 109) return "низкий";
                    if (index >= 109 & index <= 140) return "средний";
                    return "высокий";
                }
                else
                {
                    if (index < 89) return "низкий";
                    if (index >= 89 & index <= 118) return "средний";
                    return "высокий";
                }
            }
        }

        private string Letal(int index, bool st, bool gosp)
        {
            if (st)
            {
                if (gosp)
                {
                    if (index < 126) return "< 2%";
                    if (index >= 126 & index <= 154) return "2 - 5%";
                    return "> 5%";
                }
                else
                {
                    if (index < 100) return "< 4.5%";
                    if (index >= 100 & index <= 127) return "4.5 - 11%";
                    return "> 11%";
                }
            }
            else
            {
                if (gosp)
                {
                    if (index < 109) return "< 1%";
                    if (index >= 109 & index <= 140) return "1 - 3%";
                    return "> 3%";
                }
                else
                {
                    if (index < 89) return "< 3%";
                    if (index >= 89 & index <= 118) return "3 - 8%";
                    return "> 8%";
                }
            }
        }


    }
}
