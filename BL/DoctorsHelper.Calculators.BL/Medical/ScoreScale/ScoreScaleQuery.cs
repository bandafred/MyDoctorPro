using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.Medical.ScoreScale
{
    /// <summary> Модель запрос для расчета шкалы SCORE. </summary>
    public class ScoreScaleQuery : IQuery<ScoreScaleResponse>
    {
        /// <summary> Возраст  </summary>
        public int Age { get; set; }
        /// <summary> Уровень верхнего АД </summary>
        public int UpperBloodPressure { get; set; }
        /// <summary> Уровень холестерина плазмы </summary>
        public float PlasmaCholesterol { get; set; }
        /// <summary> Пол </summary>
        public bool IsMen { get; set; }
        /// <summary> Курение  </summary>
        public bool IsSmoke { get; set; }
    }
}