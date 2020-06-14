using System;
using System.Drawing;
using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Calculators.BL.Medical.BodyMassIndex
{
    /// <summary>
    /// Результат ИМТ.
    /// </summary>
    public class BodyMassIndexResponse : IStringResponse
    {
        public BodyMassIndexResponse(double index)
        {
            Index = index;
        }

        public const string DeficitResponseString = "Дефицит массы тела";
        public const string NormalResponseString = "Нормальная масса тела";
        public const string OverweightResponseString = "Избыток массы тела";
        public const string ObesityFirstDegreeResponseString = "Ожирение I степени";
        public const string ObesitySecondDegreeResponseString = "Ожирение II степени";
        public const string ObesityThirdDegreeResponseString = "Ожирение III степени";

        public const string OutOfRangeErrorString = "Неподдерживаемое значение массы тела";

        public double Index { get; }

        public string Result
        {
            get
            {
                if (Index < 18.5)
                    return DeficitResponseString;
                if (Index >= 18.5 & Index < 25)
                    return NormalResponseString;
                if (Index >= 25 & Index < 30)
                    return OverweightResponseString;
                if (Index >= 30 & Index < 35)
                    return ObesityFirstDegreeResponseString;
                if (Index >= 35 & Index < 40)
                    return ObesitySecondDegreeResponseString;
                if (Index >= 40)
                    return ObesityThirdDegreeResponseString;
                throw new ArgumentOutOfRangeException(OutOfRangeErrorString);
            }
        }

        private Color Color
        {
            get
            {
                if (Index < 18.5)
                    return Color.GreenYellow;
                if (Index >= 18.5 & Index < 25)
                    return Color.DarkGreen;
                if (Index >= 25 & Index < 30)
                    return Color.DarkOrange;
                return Color.DarkRed;
            }
        }
    }
}
