using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    internal class RentalValidator : AbstractValidator<Rental>
        //internal class'lar sadece aynı assembly üzerinden erişim sağlanabilirler. yani sadece tanımlandıkları katmandan erişime açıklardır.
    {
        public RentalValidator()
        {
            RuleFor(r => r.RentDate).LessThan(r => r.ReturnDate);
            RuleFor(r => r.ReturnDate).GreaterThan(r => r.RentDate);
        }
    }
}