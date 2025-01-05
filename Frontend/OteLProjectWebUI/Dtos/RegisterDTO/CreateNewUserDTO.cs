using System.ComponentModel.DataAnnotations;

namespace OteLProjectWebUI.Dtos.RegisterDTO
{
    public class CreateNewUserDTO
    {
        [Required(ErrorMessage ="Ad Alanı Gereklidir")]
        public string? Ad { get; set; }

        [Required(ErrorMessage ="Soyad Alanı Gereklidir")]
        public string? SoyAd { get; set; }

        [Required(ErrorMessage ="Kullanıcı Adı Gereklidir")]
        public string? UserName { get; set; }

        [Required(ErrorMessage ="Mail Alanı Gereklidir")]
        public string? Mail { get; set; }

        [Required(ErrorMessage ="Şehir Alanı Gereklidir")]
        public string? Şehir { get; set; }

        [Required(ErrorMessage ="Şifre Gereklidir")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Şifre Tekrar Gereklidir")]
        [Compare("Password",ErrorMessage ="Şifreler Uyuşmuyor")]
        public string? ConfrimPassword { get; set; }

    }
}
