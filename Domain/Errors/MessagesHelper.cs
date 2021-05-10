using System.Net;
using Domain.Constants;

namespace Domain.Errors
{
    public static class MessagesHelper
    {
        public static Error GetError(int code, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return new Error()
            {
                Code = code,
                Description = "ErrorMessages.ResourceManager.GetString(code.ToString())",
                StatusCode = statusCode
            };
        }

        public static Error GetGenericError()
        {
            return GetError(ErrorsConstants.GENERIC_ERROR);
        }
    }
}