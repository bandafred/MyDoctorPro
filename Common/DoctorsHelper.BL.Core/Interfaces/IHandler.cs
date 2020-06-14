using System.Threading.Tasks;

namespace DoctorsHelper.BL.Core.Interfaces
{
    /// <summary>
    /// Базовый интерфейс для строительства любой бизнес логики
    /// </summary>
    /// <typeparam name="TIn">Входная модель</typeparam>
    /// <typeparam name="TOut">Выходная модель</typeparam>
    public interface IHandler<in TIn, TOut>
    {
        /// <summary>
        /// Метод для обработки входящей модели и получения результирующей выходной модели
        /// </summary>
        /// <param name="input">Входная модель типа <see cref="TIn"/></param>
        /// <returns>Возвращает <see cref="Task"/>, с результатом типа <see cref="TOut"/>.
        /// Лучше при реализации подписывать async или возвращать результат через <see cref="Task.TaskFromResult"/></returns>
        Task<TOut> Handle(TIn input);
    }
}
