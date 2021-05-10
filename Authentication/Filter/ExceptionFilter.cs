using AutoMapper;
using Domain.Constants;
using Domain.Errors;
using Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;

namespace Authentication.Filter
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IMapper _mapper;
        public ExceptionFilter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void OnException(ExceptionContext context)
        {
            if (context == null)
            {
                return;
            }

            var exception = context.Exception;
            context.Result = ExceptionHandler(exception);
        }

        private IActionResult ExceptionHandler(Exception exception)
        {
            if (exception == null)
            {
                var error = MessagesHelper.GetGenericError();
                return GetResponseFromErrorMessage(error);
            }

            switch (exception)
            {
                case AggregateException aggregateException:
                    return ExceptionHandler(aggregateException.InnerException);

                case AutoMapperMappingException mappingException:
                    return ExceptionHandler(mappingException.InnerException);

                case BusinessException businessException:
                    return GetResponseFromErrorMessage(businessException.Errors);

                default:
                    return GetResponseFromErrorMessage(MessagesHelper.GetGenericError());
            }
        }

        private IActionResult GetResponseFromErrorMessage(Error error)
        {
            return new ObjectResult(new { errors = new List<Error> { error } })
            {
                StatusCode = (int)error.StatusCode
            };
        }

        private IActionResult GetResponseFromErrorMessage(IEnumerable<Error> errors)
        {
            return new ObjectResult(new { errors })
            {
                StatusCode = 400
            };
        }
    }
}