using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DoctorsHelper.Calculators.BL.Medical.CorrectedQTCalculation
{
    /// <summary>
    /// Результат рассчета корригированного QT.
    /// </summary>
    public class CorrectedQTCalculationResponse
    {
        [JsonIgnore] public double HeartRate { get; }
        [JsonIgnore] public double IntervalRR { get; }
        [JsonIgnore] public double Bazett { get; }
        [JsonIgnore] public double Fridericia { get; }
        [JsonIgnore] public double Framingham { get; }
        [JsonIgnore] public double Hodges { get; }

        /// <summary>
        /// Формула Базетта (Bazett’s formula) может быть использована у пациентов с ЧСС от 60 до 100 ударов в минуту. При тахикардии или брадикардии значения могут быть искажены.
        /// Для ЧСС ниже 60 или выше 100 ударов в минуту определение корригированного значения интервала QT должно быть подсчитано по формуле Framingham.
        /// </summary>
        /// <returns></returns>
        [JsonIgnore]
        private string Rewsume
        {
            get
            {
                if (HeartRate >= 60 && HeartRate <= 100)
                {
                    if (Bazett < 350) return ShortQT;
                    if (Bazett > 500 && Bazett <= 600) return Piruet;
                    if (Bazett > 600) return Danger;
                }
                else
                {
                    if (Framingham < 350) return ShortQT;
                    if (Framingham > 500 && Bazett <= 600) return Piruet;
                    if (Framingham > 600) return Danger;
                }

                return Norms;
            }
        }

        [JsonIgnore]
        private string Interpritation => HeartRate >= 60 && HeartRate <= 100
            ? RecommendedBazett
            : RecommendedFridericiaAndFramingham;

        /// <summary>
        /// Результат рассчета корригированного QT.
        /// </summary>
        /// <param name="intervalRR">Интервал R-R.</param>
        /// <param name="bazett">Расчет формулы Bazett.</param>
        /// <param name="fridericia">Расчет формулы Fridericia.</param>
        /// <param name="framingham">Расчет формулы Framingham.</param>
        /// <param name="hodges">Расчет формулы Hodges.</param>
        /// <param name="heartRate">Число сердечных сокращений.</param>
        public CorrectedQTCalculationResponse(double intervalRR, double bazett, double fridericia, double framingham, double hodges, int heartRate)
        {
            IntervalRR = intervalRR;
            Bazett = bazett;
            Fridericia = fridericia;
            Framingham = framingham;
            Hodges = hodges;
            HeartRate = heartRate;
        }

        public const string ShortQT = "Аномально короткий интервал QTc";
        public const string Piruet = "Повышенный риск развития потенциально опасной для жизни пируэтной желудочковой тахикардии (Torsades de Pointes)";
        public const string Danger = "Интервал QTc является очень опасным и требует не только коррекции провоцирующих факторов, но и активных методов лечения";
        public const string Norms = "QTc - в пределах нормы";
        public const string RecommendedBazett = "Формула Bazett наиболее рекомендуема";
        public const string RecommendedFridericiaAndFramingham = "Формулы Fridericia и Framingham наиболее рекомендуемы";
        public const string IntervalRRString = "RR интервал =";
        public const string Second = "сек.";
        public const string MilliSecond = "мсек.";
        public const string FormulaBazett = "Формула Bazett QTс =";
        public const string FormulaFridericia = "Формула Fridericia QTс =";
        public const string FormulaFramingham = "Формула Framingham  QTс =";
        public const string FormulaHodges = "Формула Hodges  QTс =";

        public List<string> Result
        {
            get
            {
                var result = new List<string>
                {
                    $"{IntervalRRString} {Math.Round(IntervalRR, 3)} {Second}",
                    $"{FormulaBazett} {Math.Round(Bazett)} {MilliSecond}",
                    $"{FormulaFridericia} {Math.Round(Fridericia)} {MilliSecond}",
                    $"{FormulaFramingham} {Math.Round(Framingham)} {MilliSecond}",
                    $"{FormulaHodges} {Math.Round(Hodges)} {MilliSecond}",
                    Interpritation,
                    Rewsume
                };

                return result;
            }
        }
    }
}