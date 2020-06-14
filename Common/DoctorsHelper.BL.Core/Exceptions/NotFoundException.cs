using System;
using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.BL.Core.Exceptions
{
    public class NotFoundException : Exception, IHasUserMessage
    {
        public NotFoundException(string userMessage)
        {
            UserMessage = userMessage;
        }

        public string UserMessage { get; }
    }
}
