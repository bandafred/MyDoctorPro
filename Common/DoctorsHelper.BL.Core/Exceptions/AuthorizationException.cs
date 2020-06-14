using System;
using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.BL.Core.Exceptions
{
    public class AuthorizationException : Exception, IHasUserMessage
    {
        public AuthorizationException(string userMessage)
        {
            UserMessage = userMessage;
        }

        public string UserMessage { get; }
    }
}