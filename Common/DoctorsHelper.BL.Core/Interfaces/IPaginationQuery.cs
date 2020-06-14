namespace DoctorsHelper.BL.Core.Interfaces
{
    /// <summary>
    /// Интерфейс для пагинации через запрос
    /// </summary>
    public interface IPaginationQuery<out T> : IQuery<T>
    {
        /// <summary> Количество пропускаемых записей </summary>
        public int SkipCount { get; set; }

        /// <summary> Количество отдаваемых записей </summary>
        public int TakeCount { get; set; }
    }
}
