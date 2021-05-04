using System;
using Domain.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Core.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Role).NotEmpty().When(m => m.Role?.ToLower() != "manager" || m.Role?.ToLower() != "employee").WithMessage("ROLE: Must be manager or employee");
        }
    }
}