namespace DoctorsHelper.BL.Core.Interfaces
{
    /// <summary>
    /// Интерфейс ответа с результатом в виде <see cref="string"/>
    /// </summary>
    public interface IStringResponse
    {
        /// <summary>
        /// Результат в виде <see cref="string"/>
        /// </summary>
        public string Result { get; }
    }
}