using System.Collections.Generic;
using Domain.Errors;
using System;
using System.Net;
using System.Runtime.Serialization;
using System.Linq;

namespace Core.Exceptions
{
    [Serializable]
    public class BusinessException : Exception
    {
        public IEnumerable<Error> Errors { get; set; }
        public BusinessException(IEnumerable<Error> errors)
        {
            Errors = errors;
        }

        public BusinessException(int code)
        {
            Errors = new List<Error> { MessagesHelper.GetError(code) };
        }

        public BusinessException(int code, Exception innerException)
            : base(innerException.Message, innerException)
        {
            Errors = new List<Error> { MessagesHelper.GetError(code) };
        }

        public BusinessException(IEnumerable<int> codes)
        {
            Errors = codes.Select(e => MessagesHelper.GetError(e));
        }

        public BusinessException()
        {
        }

        public BusinessException(string message)
            : base(message)
        {
        }

        public BusinessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected BusinessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}