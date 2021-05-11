using System.Collections.Generic;
using Domain.Errors;
using System;
using System.Net;
using System.Runtime.Serialization;
using System.Linq;

namespace Core.Exceptions
{
    [Serializable]
    public class ArgumentBusinessException : Exception
    {
        public IEnumerable<Error> Errors { get; set; }
        public ArgumentBusinessException(IEnumerable<Error> errors)
        {
            Errors = errors;
        }

        public ArgumentBusinessException(int code)
        {
            Errors = new List<Error> { MessagesHelper.GetError(code) };
        }

        public ArgumentBusinessException(int code, string propertyName)
        {
            Errors = new List<Error> { MessagesHelper.GetError(code, propertyName) };
        }

        public ArgumentBusinessException(int code, Exception innerException)
            : base(innerException.Message, innerException)
        {
            Errors = new List<Error> { MessagesHelper.GetError(code) };
        }

        public ArgumentBusinessException(IEnumerable<int> codes)
        {
            Errors = codes.Select(e => MessagesHelper.GetError(e));
        }

        public ArgumentBusinessException(IEnumerable<PropertyError> properties)
        {
            Errors = properties.Select(e => MessagesHelper.GetError(e.Code, e.PropertyName));
        }

        public ArgumentBusinessException()
        {
        }

        public ArgumentBusinessException(string message)
            : base(message)
        {
        }

        public ArgumentBusinessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ArgumentBusinessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}