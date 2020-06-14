namespace DoctorsHelper.BL.Core.Response
{
    /// <summary>
    /// Класс отражающий один объект для стандартизированных справочников
    /// </summary>
    /// <typeparam name="TId">Тип идентификатора</typeparam>
    /// <typeparam name="TValue">Тип значения</typeparam>
    public class IdValueItem<TId,TValue>
    {
        public IdValueItem(TId id, TValue value)
        {
            Id = id;
            Value = value;
        }

        /// <summary> Идентификатор </summary>
        public TId Id { get; }
        
        /// <summary> Значение </summary>
        public TValue Value { get; }
    }
}