using System.Collections.Generic;

namespace DoctorsHelper.BL.Core.Response
{
    public class ErrorListResponse
    {
        public ErrorListResponse(List<string> errors)
        {
            Errors = errors;
        }
        public ErrorListResponse(string error)
        {
            Errors = new List<string> { error };
        }

        public List<string> Errors { get; }
    }
}