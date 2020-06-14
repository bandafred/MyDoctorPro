using System;
using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Interfaces;
using FluentValidation;

namespace DoctorsHelper.Calculators.BL.Medical.GlomerularFiltrationRate
{
    /// <summary>
    /// Хендлер для получения <see cref="GlomerularFiltrationRateResponse"/> из <see cref="GlomerularFiltrationRateQuery"/>
    /// Расчет скорости клубочковой фильтрации.
    /// </summary>
    public class GlomerularFiltrationRateHandler : IQueryHandler<GlomerularFiltrationRateQuery, GlomerularFiltrationRateResponse>
    {
        public async Task<GlomerularFiltrationRateResponse> Handle(GlomerularFiltrationRateQuery input)
        {
            await new GlomerularFiltrationRateQueryValidator().ValidateAndThrowAsync(input);

            #region Коэффициенты

            var a = input.IsMen ? 141 : 144;
            var b = input.IsMen ? 79.6 : 61.9;
            var c = input.IsMen ? -0.411 : 0.329; 
            if (input.Creatinin > 62) c = -1.209;
            var CokcroftGaultCalcing = (140 - input.Age) * input.Weight / (input.Creatinin * 0.8);
            var MDRDCalcing = 186.3 * Math.Pow((input.Creatinin / 88.4), -1.154) * Math.Pow(input.Age, -0.203);

            #endregion

            #region Формулы

            var BodyArea = Math.Pow(input.Weight, 0.425) * (Math.Pow(input.Height, 0.725) * 0.007184);
            var CokcroftGault = input.IsMen ? CokcroftGaultCalcing : CokcroftGaultCalcing * 0.85;
            var CokcroftGaultTwo = Math.Round(CokcroftGault * 1.73 / BodyArea);
            var MDRD = input.IsMen ? MDRDCalcing : MDRDCalcing * 0.742;
            var CKDEPI = a * Math.Pow((input.Creatinin / b), c) * Math.Pow(0.993, input.Age);
                  
            #endregion


            var result = new GlomerularFiltrationRateResponse(BodyArea, CokcroftGault, CokcroftGaultTwo, MDRD, CKDEPI);

            return result;
        }
    }
}