using System.ComponentModel.DataAnnotations;

namespace DoctorsHelper.Calculators.BL.Medical.AntihypertensiveTherapy
{
    /// <summary> Группы препаратов </summary>
    public enum AntihypertensiveTherapyGroupOfDrugsEnum
    {
        ///<summary> Петлевые диуретики </summary>
        [Display(Name = "Петлевые диуретики")]
        LoopDiuretics,

        ///<summary> Диуретики антагонисты альдостерона </summary>
        [Display(Name = "Диуретики антагонисты альдостерона")]
        AldosteroneAntagonists,

        ///<summary> Диуретики тиазидные </summary>
        [Display(Name = "Диуретики тиазидные")]
        ThiazideDiuretics,

        ///<summary> Недигидропиридиновые антагонисты кальция </summary>
        [Display(Name = "Недигидропиридиновые антагонисты кальция")]
        NonDihydropyridineCalciumAntagonists,

        ///<summary> Дигидропиридиновые антагонисты кальция </summary>
        [Display(Name = "Дигидропиридиновые антагонисты кальция")]
        DihydropyridineCalciumAntagonists,

        ///<summary> Бета-адреноблокаторы </summary>
        [Display(Name = "Бета-адреноблокаторы")]
        BetaBlockers,

        ///<summary> Блокаторы кальциевых каналов </summary>
        [Display(Name = "Блокаторы кальциевых каналов")]
        CalciumChannelBlockers,

        ///<summary> Ингибиторы аденозин превращающего фермента </summary>
        [Display(Name = "Ингибиторы аденозин превращающего фермента")]
        InhibitorsOfAdenosineConvertingEnzyme,
    }
}