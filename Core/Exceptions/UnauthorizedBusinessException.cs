using System.Collections.Generic;
using Domain.Errors;
using System;
using System.Net;
using System.Runtime.Serialization;
using System.Linq;

namespace Core.Exceptions
{
    [Serializable]
    public class UnauthorizedBusinessException : Exception
    {
        public IEnumerable<Error> Errors { get; set; }
        public UnauthorizedBusinessException(IEnumerable<Error> errors)
        {
            Errors = errors;
        }

        public UnauthorizedBusinessException(int code)
        {
            Errors = new List<Error> { MessagesHelper.GetError(code) };
        }

        public UnauthorizedBusinessException(int code, string propertyName)
        {
            Errors = new List<Error> { MessagesHelper.GetError(code, propertyName) };
        }

        public UnauthorizedBusinessException(int code, Exception innerException)
            : base(innerException.Message, innerException)
        {
            Errors = new List<Error> { MessagesHelper.GetError(code) };
        }

        public UnauthorizedBusinessException(IEnumerable<int> codes)
        {
            Errors = codes.Select(e => MessagesHelper.GetError(e));
        }

        public UnauthorizedBusinessException(IEnumerable<PropertyError> properties)
        {
            Errors = properties.Select(e => MessagesHelper.GetError(e.Code, e.PropertyName));
        }

        public UnauthorizedBusinessException()
        {
        }

        public UnauthorizedBusinessException(string message)
            : base(message)
        {
        }

        public UnauthorizedBusinessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected UnauthorizedBusinessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}