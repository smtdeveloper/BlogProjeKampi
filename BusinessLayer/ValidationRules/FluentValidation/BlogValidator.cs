using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
   public class BlogValidator :   AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen Blog Başlığını Boş Bırakmayınız!");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Lütfen Blog İçeriğini Boş Bırakmayınız!");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Lütfen Blog Dosya Yolunu Boş Bırakmayınız!");
            RuleFor(x => x.Title).MaximumLength(150).WithMessage("Lütfen 150 Karakter'den daha az Veri Girişi Yapınız!");
            RuleFor(x => x.Content).MinimumLength(80).WithMessage("Lütfen 80 Karakter'den daha fazla Veri Girişi Yapınız!");
        }
    }
}
