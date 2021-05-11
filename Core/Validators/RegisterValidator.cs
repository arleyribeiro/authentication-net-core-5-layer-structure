using Core.Exceptions;
using Domain.Constants;
using Domain.DTOs.Request;
using Domain.Errors;
using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;

namespace Core.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage(ErrorsConstants.REQUIRED_PARAMETER.ToString());

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(ErrorsConstants.REQUIRED_PARAMETER.ToString())
                .MinimumLength(10).WithMessage(ErrorsConstants.Register.MIN_LENGTH_PASSWORD.ToString())
                .MaximumLength(10).WithMessage(ErrorsConstants.Register.MAX_LENGTH_PASSWORD.ToString());

            RuleFor(x => x.Role)
                .NotEmpty().WithMessage(ErrorsConstants.REQUIRED_PARAMETER.ToString())
                .When(m => m.Role?.ToLower() != "manager" && m.Role?.ToLower() != "employee")
                .WithMessage(ErrorsConstants.Register.INVALID_ROLE.ToString());
        }

        public static void ValidateAndThrowExceptionIfExistError(RegisterRequest register)
        {
            var _validator = new RegisterValidator();
            var results = _validator.Validate(register);
            if (!results.IsValid)
            {
                var errors = new List<PropertyError>();
                foreach (var item in results.Errors)
                {
                    try
                    {
                        var code = Convert.ToInt32(item.ErrorMessage);
                        errors.Add(new PropertyError { Code = code, PropertyName = item.PropertyName });
                    }
                    catch
                    {

                    }
                }
                throw new ArgumentBusinessException(errors);
            }
        }
    }
}