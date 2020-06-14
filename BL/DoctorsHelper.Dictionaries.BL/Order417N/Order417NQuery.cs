using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Dictionaries.BL.Order417N
{
    /// <summary>
    /// Модель запроса для <see cref="Order417NResponse"/>
    /// </summary>
    public class Order417NQuery : ISearchTextQuery<Order417NResponse>
    {
        /// <inheritdoc />
        public string SearchText { get; set; }
    }
}