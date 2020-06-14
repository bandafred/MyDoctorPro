namespace DoctorsHelper.ArterialPressure.BL.Email
{
    /// <summary> Конфигурация <see cref="EmailSender"/> </summary>
    public class EmailSenderConfiguration
    {
        /// <summary> Имя отправителя </summary>
        public string EmailSenderName { get; set; }

        /// <summary> Email отправителя </summary>
        public string EmailSenderEmail { get; set; }

        /// <summary> Пароль для Email отправителя </summary>
        public string EmailSenderPassword { get; set; }

        /// <summary> Хост почтового сервере smtp </summary>
        public string SmtpServerHost { get; set; }

        /// <summary> Порт почтового сервера smtp </summary>
        public int SmtpServerPort { get; set; }
    }
}