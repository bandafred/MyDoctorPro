using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Interfaces;
using FluentValidation;

namespace DoctorsHelper.Calculators.BL.Medical.ScoreScale
{
    /// <summary>
    /// Хендлер для получения <see cref="ScoreScaleResponse"/> из <see cref="ScoreScaleQuery"/>
    /// Шкала SCORE (Systematic COronary Risk Evaluation) разработана для оценки
    /// риска смертельного сердечно-сосудистого заболевания в течение 10 лет.
    /// Основой для шкалы послужили данные когортных исследований,
    /// проведенных в 12 странах Европы (включая Россию), с общей численностью 205 178 человек.
    /// Для лиц молодого возраста (моложе 40 лет) определяется не абсолютный,
    /// а относительный суммарный СС риск с использованием другой шкалы.
    /// Расчеты производятся автоматически в зависимости от возраста.
    /// </summary>
    public class ScoreScaleHandler : IQueryHandler<ScoreScaleQuery, ScoreScaleResponse>
    {
        public async Task<ScoreScaleResponse> Handle(ScoreScaleQuery input)
        {
            await new ScoreScaleQueryValidator().ValidateAndThrowAsync(input);

            var index = GetResult(input.Age, input.IsMen, input.IsSmoke ? 1 : 0,
                GetUpperBloodPressureIndex(input.UpperBloodPressure),
                GetPlasmaCholesterolIndex(input.PlasmaCholesterol));

            var result = new ScoreScaleResponse(index, input.Age < 40);

            return result;
        }

        /// <summary>
        /// Рассчитывает индекс по шкале SCORE
        /// </summary>
        /// <param name="age">Возраст</param>
        /// <param name="isMen">Мужчина</param>
        /// <param name="isSmokerIndex">Индекс параметра "Курение"</param>
        /// <param name="upperBloodPressureIndex">Индекс параметра "Уровень верхнего АД"</param>
        /// <param name="plasmaCholesterolIndex">Индекс параметра "Уровень холестерина плазмы"</param>
        /// <returns>Bндекс по шкале SCORE</returns>
        private static int GetResult(int age, bool isMen, int isSmokerIndex, int upperBloodPressureIndex,
            int plasmaCholesterolIndex)
        {
            if (age < 40)
                return ScoreScaleTableValues.Under40[isSmokerIndex, upperBloodPressureIndex, plasmaCholesterolIndex];

            if (age >= 40 && age < 50)
                return isMen
                    ? ScoreScaleTableValues.Between40And50Men[isSmokerIndex, upperBloodPressureIndex,
                        plasmaCholesterolIndex]
                    : ScoreScaleTableValues.Between40And50Women[isSmokerIndex, upperBloodPressureIndex,
                        plasmaCholesterolIndex];

            if (age >= 50 && age < 55)
                return isMen
                    ? ScoreScaleTableValues.Between50And55Men[isSmokerIndex, upperBloodPressureIndex,
                        plasmaCholesterolIndex]
                    : ScoreScaleTableValues.Between50And55Women[isSmokerIndex, upperBloodPressureIndex,
                        plasmaCholesterolIndex];

            if (age >= 55 && age < 60)
                return isMen
                    ? ScoreScaleTableValues.Between55And60Men[isSmokerIndex, upperBloodPressureIndex,
                        plasmaCholesterolIndex]
                    : ScoreScaleTableValues.Between55And60Women[isSmokerIndex, upperBloodPressureIndex,
                        plasmaCholesterolIndex];

            if (age >= 60 && age < 65)
                return isMen
                    ? ScoreScaleTableValues.Between60And65Men[isSmokerIndex, upperBloodPressureIndex,
                        plasmaCholesterolIndex]
                    : ScoreScaleTableValues.Between60And65Women[isSmokerIndex, upperBloodPressureIndex,
                        plasmaCholesterolIndex];

            return isMen
                ? ScoreScaleTableValues.More65Men[isSmokerIndex, upperBloodPressureIndex,
                    plasmaCholesterolIndex]
                : ScoreScaleTableValues.More65Women[isSmokerIndex, upperBloodPressureIndex,
                    plasmaCholesterolIndex];
        }


        private static int GetPlasmaCholesterolIndex(double plasmaCholesterol)
        {
            if (plasmaCholesterol <= 4)
                return 0;
            if (plasmaCholesterol > 4 & plasmaCholesterol <= 5)
                return 1;
            if (plasmaCholesterol > 5 & plasmaCholesterol <= 6)
                return 2;
            if (plasmaCholesterol > 6 & plasmaCholesterol <= 7)
                return 3;
            return 4;
        }

        private static int GetUpperBloodPressureIndex(int upperBloodPressure)
        {
            if (upperBloodPressure >= 180)
                return 0;
            if (upperBloodPressure >= 160 & upperBloodPressure < 180)
                return 1;
            if (upperBloodPressure >= 140 & upperBloodPressure < 160)
                return 2;
            return 3;
        }
    }
}