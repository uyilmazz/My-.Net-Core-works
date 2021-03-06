using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.UserId).NotEmpty();
            RuleFor(c => c.UserId).GreaterThan(0);
            RuleFor(c => c.FindexScore).GreaterThan(0);
            RuleFor(c => c.FindexScore).LessThan(1900);
           
        }
    }
}
