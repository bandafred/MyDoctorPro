namespace DoctorsHelper.BL.Core.Interfaces
{
    /// <summary>
    /// Интерфейс для поиск по тексту через запрос
    /// </summary>
    public interface ISearchTextQuery<out T> : IQuery<T>
    {
        /// <summary>  Строка для поиска </summary>
        public string SearchText { get; set; }
    }
}