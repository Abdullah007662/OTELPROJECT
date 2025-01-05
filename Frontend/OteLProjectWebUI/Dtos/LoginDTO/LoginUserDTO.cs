using System.ComponentModel.DataAnnotations;

namespace OteLProjectWebUI.Dtos.LoginDTO
{
    public class LoginUserDTO
    {
        [Required(ErrorMessage ="Kullanıcı Adını Giriniz")]
        public string? Kullanıcı_Adı { get; set; }
        
        [Required(ErrorMessage ="Şifre Giriniz")]
        public string? Şifre { get; set; }
    }
}
