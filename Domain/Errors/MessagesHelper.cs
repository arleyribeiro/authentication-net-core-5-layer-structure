using System.Net;
using Domain.Constants;

namespace Domain.Errors
{
    public static class MessagesHelper
    {
        public static Error GetError(int code)
        {
            return new Error()
            {
                Code = code,
                Description = "ErrorMessages.ResourceManager.GetString(code.ToString())"
            };
        }

        public static Error GetError(int code, string propertyName)
        {
            return new Error()
            {
                Code = code,
                PropertyName = propertyName,
                Description = "ErrorMessages.ResourceManager.GetString(code.ToString())",
            };
        }

        public static Error GetGenericError()
        {
            return GetError(ErrorsConstants.GENERIC_ERROR);
        }
    }
}