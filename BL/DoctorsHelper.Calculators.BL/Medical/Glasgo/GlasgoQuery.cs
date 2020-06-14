using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.Medical.Glasgo
{
    /// <summary> Модель запрос для расчета шкала комы Глазго. </summary>
    public class GlasgoQuery : IQuery<GlasgoResponse>
    {
        /// <summary>Открывание глаз.</summary>
        public int EyeResponse { get; set; }

        /// <summary>Речевая реакция.</summary>
        public int VerbalResponse { get; set; }

        /// <summary>Двигательная реакция.</summary>
        public int MotorResponse { get; set; }
    }
}