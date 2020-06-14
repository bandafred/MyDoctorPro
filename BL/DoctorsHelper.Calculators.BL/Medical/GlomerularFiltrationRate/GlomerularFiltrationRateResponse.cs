using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DoctorsHelper.Calculators.BL.Medical.GlomerularFiltrationRate
{
    /// <summary>
    /// Результат рассчета скорости клубочковой фильтрации.
    /// </summary>
    public class GlomerularFiltrationRateResponse
    {
        [JsonIgnore] public double BodyArea { get; }
        [JsonIgnore] public double CokcroftGault { get; }
        [JsonIgnore] public double CokcroftGaultTwo { get; }
        [JsonIgnore] public double MDRD { get; }
        [JsonIgnore] public double CKDEPI { get; }

        #region Константы

        public const string FirstStage = "При отсутствии других признаков ХБП, данная скорость клубочковой фильтрации является нормальной, иначе - повреждение почек с нормальной или повышенной СКФ. 1 стадия ХПН.";
        public const string SecondStage = "Повреждение почек с лёгким снижением СКФ. 2 стадия ХПН.";
        public const string ThirdStage = "Умеренное снижение СКФ. 3 стадия ХПН.";
        public const string FourthStage = "Выраженное снижение СКФ. 4 стадия ХПН.";
        public const string FifthStage = "Почечная недостаточность. 5 стадия ХПН.";
        public const string BodyAreaString = "Площадь тела";
        public const string CokcroftGaultString = "СКФ по Cokcroft-Gault";
        public const string MDRDString = "Формула MDRD";
        public const string CKDEPIString = "Формула CKD-EPI";
        public const string SQM = "кв.м";
        public const string MlMin = "мл/мин";
        public const string MlMinSqm = "мл/мин/1,73 кв.м";

            #endregion

        [JsonIgnore]
        public string Rewsume
        {
            get
            {
                if (CokcroftGault >= 90) return FirstStage;
                if (CokcroftGault < 90 & CokcroftGault >= 60) return SecondStage;
                if (CokcroftGault < 60 & CokcroftGault >= 30) return ThirdStage;
                if (CokcroftGault < 30 & CokcroftGault >= 15) return FourthStage;
                return FifthStage;
            }
        }

        /// <summary>
        /// Результат рассчета скорости клубочковой фильтрации.
        /// </summary>
        /// <param name="bodyArea">Площадь тела (кв.м).</param>
        /// <param name="cokcroftGault">СКФ по Cokcroft-Gault (мл/мин).</param>
        /// <param name="cokcroftGaultTwo">СКФ по Cokcroft-Gault (мл/мин/1,73 кв.м).</param>
        /// <param name="mdrd">Формула MDRD(мл/мин/1,73 м2).</param>
        /// <param name="ckdepi">Формула CKD-EPI (мл/мин/1,73 м2).</param>
        public GlomerularFiltrationRateResponse(double bodyArea, double cokcroftGault, double cokcroftGaultTwo, double mdrd, double ckdepi)
        {
            BodyArea = bodyArea;
            CokcroftGault = cokcroftGault;
            CokcroftGaultTwo = cokcroftGaultTwo;
            MDRD = mdrd;
            CKDEPI = ckdepi;
        }

        public List<string> Result
        {
            get
            {
                var result = new List<string>
                {
                    $"{BodyAreaString} - {Math.Round(BodyArea, 2)} {SQM} ",
                    $"{CokcroftGaultString} - {Math.Round(CokcroftGault)} {MlMin}",
                    $"{CokcroftGaultString} - {Math.Round(CokcroftGaultTwo)} {MlMinSqm}",
                    $"{MDRDString} - {Math.Round(MDRD)} {MlMinSqm}",
                    $"{CKDEPIString} - {Math.Round(CKDEPI)} {MlMinSqm}",
                    Rewsume
                };

                return result;
            }
        }
    }
}