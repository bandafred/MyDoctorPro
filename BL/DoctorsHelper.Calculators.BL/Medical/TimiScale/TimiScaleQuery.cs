using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.Medical.TimiScale
{
    /// <summary> Модель запрос для расчета шкалы TIMI. </summary>
    public class TimiScaleQuery : IQuery<TimiScaleResponse>
    {
        /// <summary> Возраст > 65 лет </summary>
        public bool OldAge { get; set; }
        /// <summary> Наличие трех и более факторов риска атеросклероза </summary>
        public bool ThreeRisk { get; set; }
        /// <summary> Ранее выявленный стеноз коронарной артерии более 50% диаметра </summary>
        public bool Stenos { get; set; }
        /// <summary> Подъем или депрессия сегмента ST на ЭКГ при поступлении </summary>
        public bool LiftSt { get; set; }
        /// <summary> Два и более приступа стенокардии за последние 24 часа </summary>
        public bool Stenocardia { get; set; }
        /// <summary> Прием аспирина в течение последних 7 суток </summary>
        public bool Aspirin { get; set; }
        /// <summary> Повышение маркеров некроза миокарда </summary>
        public bool Necroze { get; set; }
    }
}