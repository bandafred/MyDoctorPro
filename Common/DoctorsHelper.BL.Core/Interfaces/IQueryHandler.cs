namespace DoctorsHelper.BL.Core.Interfaces
{
    /// <summary>
    /// Основной интерфейс для описания бизнес логики обрабатывающей запросы(<see cref="IQuery{TOut}"/>)
    /// </summary>
    /// <typeparam name="TIn">Входящая модель запроса(<see cref="IQuery{TOut}"/>) для обработки</typeparam>
    /// <typeparam name="TOut">Выходная модель запроса - результат</typeparam>
    public interface IQueryHandler<in TIn, TOut> : IHandler<TIn, TOut> where TIn : IQuery<TOut>
    {

    }
}