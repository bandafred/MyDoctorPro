using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Dictionaries.BL.Mkb10
{
    /// <summary>
    /// Модель запроса для <see cref="Mkb10Response"/>
    /// </summary>
    public class Mkb10Query : IPaginationQuery<Mkb10Response>, ISearchTextQuery<Mkb10Response>
    {
        /// <inheritdoc />
        public string SearchText { get; set; }

        /// <inheritdoc />
        public int SkipCount { get; set; }

        /// <inheritdoc />
        public int TakeCount { get; set; }
    }
}