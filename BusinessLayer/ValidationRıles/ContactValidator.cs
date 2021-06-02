using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRıles
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Adresi boş Geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Adını boş Geçemezsiniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Konu Adını boş Geçemezsiniz");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Lütfen en az 3 Karekter Giriniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 Karekter Giriniz");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lütfen en fazla 50 Karekter Giriniz");
        }
    }
}
