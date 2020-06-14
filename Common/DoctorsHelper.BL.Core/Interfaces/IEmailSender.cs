using System.Threading.Tasks;

namespace DoctorsHelper.BL.Core.Interfaces
{
    /// <summary> Интерфейс для класса отвечающего за отправку писем </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// Отправить письмо на указанный Email, с указанной темой и сообщением
        /// </summary>
        /// <param name="email">Email куда отправить письмо</param>
        /// <param name="subject">Тема письма</param>
        /// <param name="message">Содержание письма</param>
        public Task SendEmailAsync(string email, string subject, string message);
    }
}