using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
  public  class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            //RuleFor(x => x.Name).NotEmpty().WithMessage("Ad Soyad Boş Geçilemez");
            //RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Boş Geçilemez");
            //RuleFor(x => x.Password).NotEmpty().WithMessage("Parola Boş Geçilemez");
            //RuleFor(x => x.City).NotEmpty().WithMessage("Sehir Boş Geçilemez");
            //RuleFor(x => x.About).NotEmpty().WithMessage("Bio Boş Geçilemez");
           
           
            //RuleFor(x => x.Password).Must(IsPasswordValid).WithMessage("Parola en az 6 karakter olmalıdır, en az bir küçük harf bir büyük harf ve rakam olmalıdır");

        }

        private bool IsPasswordValid(string arg)
        {
            try
            {
                Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[0-9])[A-Za-z\d]{6,}$");
                return regex.IsMatch(arg);
            }
            catch
            {
                return false;
            }
        }
    }
}
