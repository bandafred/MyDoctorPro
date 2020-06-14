using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.Medical.ContrastInducedNephropathy
{
    /// <summary>
    /// Модель запрос для вероятности развития контраст индуцированной нефропатии.
    /// </summary>
    public class ContrastInducedNephropathyQuery : IQuery<ContrastInducedNephropathyResponse>
    {
        /// <summary>
        /// Гипотония – АД менее 90/60 мм рт.ст.
        /// </summary>
        public bool IsHypotonia { get; set; }

        /// <summary>
        /// Применение внутриаортальной баллонной контрпульсации (ВАБК).
        /// </summary>
        public bool IsVABK { get; set; }

        /// <summary>
        /// Сердечная недостаточность (класс III-IV NYHA)
        /// </summary>
        public bool IsNYHA { get; set; }

        /// <summary>
        /// Возраст старше 75 лет.
        /// </summary>
        public bool IsOldAge { get; set; }

        /// <summary>
        /// Анемия – Hb < 12 г/дл для женщин, Hb < 13 г/дл для мужчин.
        /// </summary>
        public bool IsAnemya { get; set; }

        /// <summary>
        /// Сахарный диабет.
        /// </summary>
        public bool IsDiabetes { get; set; }

        /// <summary>
        /// Уровень креатинина > 132,6 мкмоль/л (1,5 мг/дл).
        /// </summary>
        public bool IsBigCreatinin { get; set; }

        /// <summary>
        /// Объем введенного контрастного вещества.
        /// </summary>
        public int VolumeContrast { get; set; }

        /// <summary>
        /// Скорость клубочковой фильтрации.
        /// </summary>
        public int SpeedKF { get; set; }
    }
}