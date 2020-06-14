using System.ComponentModel.DataAnnotations;

namespace DoctorsHelper.Calculators.BL.Medical.AntihypertensiveTherapy
{
    /// <summary> Заболевания </summary>
    public enum AntihypertensiveTherapyDiseaseEnum
    {
        ///<summary> Ишемическая болезнь сердца </summary>
        [Display(Name = "Ишемическая болезнь сердца")]
        CoronaryHeartDisease,

        ///<summary> Гипертрофия левого желудочка </summary>
        [Display(Name = "Гипертрофия левого желудочка")]
        LeftVentricularHypertrophy,

        ///<summary> Мерцательная аритмия </summary>
        [Display(Name = "Мерцательная аритмия")]
        AtrialFibrillation,

        ///<summary> Сахарный диабет </summary>
        [Display(Name = "Сахарный диабет")]
        Diabetes,

        ///<summary> Перенесенный инфаркт миокарда </summary>
        [Display(Name = "Перенесенный инфаркт миокарда")]
        MyocardialInfarction,

        ///<summary> Поражение почек </summary>
        [Display(Name = "Поражение почек")]
        KidneyDamage,

        ///<summary> Хроническая сердечная недостаточность </summary>
        [Display(Name = "Хроническая сердечная недостаточность")]
        ChronicHeartFailure,

        ///<summary> Белок в моче </summary>
        [Display(Name = "Белок в моче")]
        ProteinInTheUrine,

        ///<summary> Атеросклероз сонных и коронарных артерий </summary>
        [Display(Name = "Атеросклероз сонных и коронарных артерий")]
        AtherosclerosisOfTheCarotidAndCoronaryArteries,

        ///<summary> Глаукома </summary>
        [Display(Name = "Глаукома")]
        Glaucoma,

        ///<summary> Беременность </summary>
        [Display(Name = "Беременность")]
        Pregnancy,

        ///<summary> Тахиаритмия </summary>
        [Display(Name = "Тахиаритмия")]
        Tachyarrhythmia,

        ///<summary> Хроническая обструктивная болезнь легких </summary>
        [Display(Name = "Хроническая обструктивная болезнь легких")]
        ChronicObstructivePulmonaryDisease,

        ///<summary> Бронхиальная астма </summary>
        [Display(Name = "Бронхиальная астма")]
        BronchialAsthma,

        ///<summary> Хроническая почечная недостаточность </summary>
        [Display(Name = "Хроническая почечная недостаточность")]
        ChronicRenalFailure,

        ///<summary> Метаболический синдром </summary>
        [Display(Name = "Метаболический синдром")]
        MetabolicSyndrome,

        ///<summary> Двусторонний стеноз почечных артерий </summary>
        [Display(Name = "Двусторонний стеноз почечных артерий")]
        BilateralRenalArteryStenosis,

        ///<summary> Кашель от приема иАПФ </summary>
        [Display(Name = "Кашель от приема иАПФ")]
        CoughFromTakingAngiotensinConvertingEnzymeInhibitors,

        ///<summary> Подагра </summary>
        [Display(Name = "Подагра")]
        Gout,

        ///<summary> АВ-блокада 2-3 степени </summary>
        [Display(Name = "АВ-блокада 2-3 степени")]
        AtrioventricularBlockOfTheSecondOrThirdDegree,

        ///<summary> Гиперкалиемия </summary>
        [Display(Name = "Гиперкалиемия")]
        Hyperkalemia,

        ///<summary> Ангионевротический отек (отек Квинке) </summary>
        [Display(Name = "Ангионевротический отек (отек Квинке)")]
        AngioneuroticEdema,
    }
}