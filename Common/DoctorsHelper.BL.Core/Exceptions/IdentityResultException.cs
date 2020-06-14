using System;
using Microsoft.AspNetCore.Identity;

namespace DoctorsHelper.BL.Core.Exceptions
{
    public class IdentityResultException : Exception
    {
        public IdentityResultException(IdentityResult identityResult)
        {
            IdentityResult = identityResult;
        }

        public IdentityResult IdentityResult { get; }
    }
}
