using FluentValidation;
using FluentValidationApp.Models;

namespace FluentValidationApp.FluentValidator
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public string NotEmptyMessage { get; } = "{PropertyName} alanı boş olamaz!";
        public CustomerValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Email).NotEmpty().WithMessage(NotEmptyMessage).EmailAddress().WithMessage("Email doğru formatta olmalıdır!");
            RuleFor(x => x.Age).NotEmpty().WithMessage(NotEmptyMessage).InclusiveBetween(18,60).WithMessage("Age alanı doğru aralıkta olmalıdır!");
            RuleFor(x => x.Birthday).NotEmpty().WithMessage(NotEmptyMessage).Must(x =>
            {
                return DateTime.Now.AddYears(-18) >= x;
            }).WithMessage("18 yaş sınırı bulunmaktadır!");

            RuleForEach(x => x.Addresses).SetValidator(new AddressValidator());
            //Address class'ında yazdığımız kuralların bire çok ilişki halinde bulunan class'ına validator'ü set ediyoruz.
        }
    }
}
