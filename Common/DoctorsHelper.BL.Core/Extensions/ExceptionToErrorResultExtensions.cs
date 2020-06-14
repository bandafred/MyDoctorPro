using System;
using System.Linq;
using DoctorsHelper.BL.Core.Exceptions;
using DoctorsHelper.BL.Core.Interfaces;
using DoctorsHelper.BL.Core.Response;
using FluentValidation;

namespace DoctorsHelper.BL.Core.Extensions
{
    //TODO: Summary
    public static class ExceptionToErrorResultExtensions
    {
        public static ErrorListResponse GetErrorListResponseFromException(this Exception e)
        {
            if (e == null) return null;
            
            //TODO: Надо продумать как правильно доставать exception из AggregateException
            if (e is AggregateException aggregate && e.InnerException != null)
                e = e.InnerException;

            if (e is ValidationException validationException)
                return validationException.GetErrorListResponseFromValidationException();

            if (e is ArgumentException argumentException)
                return argumentException.GetErrorListResponseArgumentException();

            if (e is IdentityResultException identityResultException)
                return identityResultException.GetErrorListResponseIdentityResultException();

            if (e is IHasUserMessage hasUserMessage)
                return hasUserMessage.GetErrorListResponseIHasUserMessageException();

            //TODO: Добавить больше типов exception'ов
            throw new NotSupportedException();
        }

        public static ErrorListResponse GetErrorListResponseFromValidationException(this ValidationException e) =>
            new ErrorListResponse(e.Errors.Select(failure => failure.ErrorMessage).ToList());

        public static ErrorListResponse GetErrorListResponseIHasUserMessageException(this IHasUserMessage e) =>
            new ErrorListResponse(e.UserMessage);

        public static ErrorListResponse GetErrorListResponseArgumentException(this ArgumentException e) =>
            new ErrorListResponse(e.Message);

        public static ErrorListResponse GetErrorListResponseIdentityResultException(this IdentityResultException e) =>
            new ErrorListResponse(e.IdentityResult.Errors.Select(error => error.Description)
                .ToList());
    }
}
