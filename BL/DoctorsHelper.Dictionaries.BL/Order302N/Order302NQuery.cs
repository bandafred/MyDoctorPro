using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.Dictionaries.BL.Order302N
{
    /// <summary>
    /// Модель запроса для <see cref="Order302NResponse"/>
    /// </summary>
    public class Order302NQuery : ISearchTextQuery<Order302NResponse>
    {
        /// <inheritdoc />
        public string SearchText { get; set; }
    }
}