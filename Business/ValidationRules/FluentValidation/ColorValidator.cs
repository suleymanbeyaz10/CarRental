using Entities.Concrete;
using FluentValidation;
using System;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator() 
        {
            RuleFor(p => p.ColorName).NotEmpty();
            RuleFor(p => p.ColorName).MinimumLength(2);
        }
    }
}
