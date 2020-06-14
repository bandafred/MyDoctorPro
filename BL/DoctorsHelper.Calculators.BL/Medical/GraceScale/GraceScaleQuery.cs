using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.Medical.GraceScale
{
    /// <summary>
    /// Модель запрос для шкалы GRACE.
    /// </summary>
    public class GraceScaleQuery : IQuery<GraceScaleResponse>
    {
        /// <summary> Возраст, лет. </summary>
        public int Age { get; set; }
        /// <summary> ЧСС, уд/мин </summary>
        public int HeartRate { get; set; }
        /// <summary> Систолическое АД, мм.рт.ст. </summary>
        public int SystolicBloodPressure { get; set; }
        /// <summary> Креатинин, мкмоль/л </summary>
        public double Creatinin { get; set; }
        /// <summary> Класс сердечной недостаточности по Killip </summary>
        public int Kilip { get; set; }
        /// <summary> Остановка сердца </summary>
        public bool HeartFailure { get; set; }
        /// <summary> Отклонение сегмента ST </summary>
        public bool StSegmentDeviation { get; set; }
        /// <summary> Высокий уровень сердечных ферментов </summary>
        public bool HighLevelOfCardiacEnzymes { get; set; }
    }
}