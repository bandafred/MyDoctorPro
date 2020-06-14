using System.Collections.Generic;
using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.Medical.AntihypertensiveTherapy
{
    /// <summary>
    /// Модель запрос для подбора гипотензивной терапии.
    /// </summary>
    public class AntihypertensiveTherapyQuery : IQuery<AntihypertensiveTherapyResponse>
    {
        /// <summary>
        /// Возраст.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Мужской пол.
        /// </summary>
        public bool IsMen { get; set; }

        /// <summary>
        /// Систолическое АД.
        /// </summary>
        public int SystolicBloodPressure { get; set; }

        /// <summary>
        /// Диастолическое АД.
        /// </summary>
        public int DiastolicBloodPressure { get; set; }

        /// <summary>
        /// Пульс.
        /// </summary>
        public int Pulse { get; set; }

        /// <summary>
        /// Список заболеваний.
        /// </summary>
        public List<int> Diseases { get; set; }
    }
}