using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Ad boş geçilemez.");
            RuleFor(x => x.UserName).MinimumLength(2).WithMessage("Ad 2 harften az olamaz.");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Adresi boş geçilemez.");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen geçerli bir E-Mail adresi giriniz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Başlık boş geçilemez.");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj boş geçilemez.");
        }
    }
}
