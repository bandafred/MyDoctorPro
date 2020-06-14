namespace DoctorsHelper.BL.Core.Interfaces
{
    /// <summary>
    /// Интерфейс для указания моделей типа Команда, которые возвращают <see cref="TOut"/> после обработки хендлером
    /// </summary>
    /// <typeparam name="TOut">Модель которая возвращается после обработки хендлеров</typeparam>
    public interface ICommand<out TOut> { }
}