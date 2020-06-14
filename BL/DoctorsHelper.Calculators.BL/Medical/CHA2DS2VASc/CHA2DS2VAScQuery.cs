using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.Medical.CHA2DS2VASc
{
    /// <summary> Модель запрос для расчета шкалы CHA2DS2VASc. </summary>
    public class CHA2DS2VAScQuery : IQuery<CHA2DS2VAScResponse>
    {
        /// <summary>
        /// Инсульт, транзиторная ишемическая атака или артериальная тромбоэмболия в анамнезе.
        /// </summary>
        public bool IsInsult { get; set; }

        /// <summary>
        /// Возраст старше 75 лет.
        /// </summary>
        public bool IsOld75 { get; set; }

        /// <summary>
        /// Возраст 65-74 года.
        /// </summary>
        public bool IsOld65 { get; set; }

        /// <summary>
        /// Страдает АГ.
        /// </summary>
        public bool IsArterialHypertension { get; set; }

        /// <summary>
        /// Страдает сахарным диабетом.
        /// </summary>
        public bool IsDiabetes { get; set; }

        /// <summary>
        /// Застойная сердечная недостаточность/дисфункция ЛЖ (в частности, ФВ ≤40 %).
        /// </summary>
        public bool IsHeartFailure { get; set; }

        /// <summary>
        /// Сосудистое заболевание (инфаркт миокарда в анамнезе, периферический атеросклероз,атеросклеротические бляшки в аорте).
        /// </summary>
        public bool IsMyocardialInfarction{ get; set; }

        /// <summary>
        /// Женсикий пол.
        /// </summary>
        public bool IsWomen { get; set; }
    }
}