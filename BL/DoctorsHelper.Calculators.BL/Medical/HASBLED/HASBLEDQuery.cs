using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.Medical.HASBLED
{
    /// <summary> Модель запрос для расчета шкалы HAS-BLED. </summary>
    public class HASBLEDQuery : IQuery<HASBLEDResponse>
    {
        /// <summary>
        /// Артериальная гипертония (АД >160 мм рт.ст.).
        /// </summary>
        public bool Hypertension { get; set; }

        /// <summary>
        /// Нарушение функции почек (креатинин сыворотки более 200 мкмоль/л).
        /// </summary>
        public bool CreatinineIncreased { get; set; }

        /// <summary>
        /// Нарушение функции печени (повышение АЛТ/АСТ/щелочной фосфатазы > 3 раза от верхней границы нормы).
        /// </summary>
        public bool Transaminase { get; set; }

        /// <summary>
        /// Инсульт в анамнезе.
        /// </summary>
        public bool Insult { get; set; }

        /// <summary>
        /// Кровотечения (со снижением Hb>2 г/л).
        /// </summary>
        public bool Bleeding { get; set; }

        /// <summary>
        /// Неустойчивое МНО (<60% времени в терапевтическом диапазоне).
        /// </summary>
        public bool Mno { get; set; }

        /// <summary>
        /// Пожилой возраст (> 65 лет).
        /// </summary>
        public bool OldAge { get; set; }

        /// <summary>
        /// Лекарственные препараты (Совместный прием лекарств, усиливающих кровоточивость: антиагреганты, НПВП).
        /// </summary>
        public bool AntiplateletAgents { get; set; }

        /// <summary>
        /// Алкоголь (> 8 стаканов в неделю).
        /// </summary>
        public bool Alcohol { get; set; }
    }
}