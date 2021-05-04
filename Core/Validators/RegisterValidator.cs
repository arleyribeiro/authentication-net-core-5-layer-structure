using System;
using Domain.DTOs.Request;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Core.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Username).NotEmpty().MinimumLength(1).WithMessage("Username is required");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(10).MaximumLength(10).WithMessage("Password is required");
            RuleFor(x => x.Role).NotEmpty().When(m => m.Role?.ToLower() != "manager" || m.Role?.ToLower() != "employee").WithMessage("ROLE: Must be manager or employee");
        }
    }
}