using System.ComponentModel.DataAnnotations;

namespace DoctorsHelper.Calculators.BL.Medical.GraceScale
{
    public enum GraceScaleKillipEnum
    {
        ///<summary> Отсутствие признаков застойной сердечной недостаточности (I) </summary>
        [Display(Name = "Отсутствие признаков застойной сердечной недостаточности (I)")]
        LackOfEvidenceOfCongestiveHeartFailure = 0,
        ///<summary> Наличие хрипов в легких и/или повышенного давления в яремных венах (II) </summary>
        [Display(Name = "Наличие хрипов в легких и/или повышенного давления в яремных венах (II)")]
        WheezingInTheLungsAndOrIncreasedPressureInTheJugularVeins = 20,
        ///<summary> Острый отек легких (III) </summary>
        [Display(Name = "Острый отек легких (III)")]
        AcutePulmonaryEdema = 39,
        ///<summary> Кардиогенный шок (IV) </summary>
        [Display(Name = "Кардиогенный шок (IV)")]
        CardiogenicShock = 59,
    }
}