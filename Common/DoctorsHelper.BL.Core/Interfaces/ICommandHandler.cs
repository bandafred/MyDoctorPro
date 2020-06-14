namespace DoctorsHelper.BL.Core.Interfaces
{
    /// <summary>
    /// Основной интерфейс для описания бизнес логики обрабатывающей команды(<see cref="ICommand{TOut}"/>)
    /// </summary>
    /// <typeparam name="TIn">Входящая модель команды(<see cref="ICommand{TOut}"/>) для обработки</typeparam>
    /// <typeparam name="TOut">Выходная модель команды - результат</typeparam>
    public interface ICommandHandler<in TIn, TOut> : IHandler<TIn, TOut> where TIn : ICommand<TOut>
    {

    }
}