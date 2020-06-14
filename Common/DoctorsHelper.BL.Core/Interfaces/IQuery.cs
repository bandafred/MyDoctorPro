namespace DoctorsHelper.BL.Core.Interfaces
{
    /// <summary>
    /// Интерфейс для указания моделей типа Запрос, которые возвращают <see cref="TOut"/> после обработки хендлером
    /// </summary>
    /// <typeparam name="TOut">Модель которая возвращается после обработки хендлеров</typeparam>
    public interface IQuery<out TOut> { }
}