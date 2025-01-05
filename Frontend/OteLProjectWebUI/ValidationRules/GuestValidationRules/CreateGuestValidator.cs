using FluentValidation;
using OteLProjectWebUI.Dtos.GuestDTO;

namespace OteLProjectWebUI.ValidationRules.GuestValidationRules
{
    public class CreateGuestValidator : AbstractValidator<CreateGuestDTO>
    {
        public CreateGuestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad Alanı Boş Geçilemez.!");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Ad En Az 3 Karakter Olmalı..");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("Ad En Fazla 20 Karakter Olmalı..");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad Alanı Boş Geçilemez.!");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("Soyad En Az 2 Karakter Olmalı..");
            RuleFor(x => x.Surname).MaximumLength(20).WithMessage("Soyad En Fazla 20 Karakter Olmalı..");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir Alanı Boş GEçilemez.!");
            RuleFor(x => x.City).MinimumLength(3).WithMessage("Şehir En Az 3 Karakter Olmalı..");
            RuleFor(x => x.City).MaximumLength(10).WithMessage("Şehir En Fazla 10 Karakter Olmalı..");
        }
    }
}
