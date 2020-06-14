using System.Collections.Generic;

namespace DoctorsHelper.BL.Core.Interfaces
{
    //TODO: разобраться с summary
    /// <summary>
    /// Интерфейс ответа с результатом в виде <see cref="List{string}"/>
    /// </summary>
    public interface IListStringResponse
    {
        /// <summary>
        /// Результат в виде <see cref="List{string}"/>
        /// </summary>
        public List<string> Result { get; }
    }
}