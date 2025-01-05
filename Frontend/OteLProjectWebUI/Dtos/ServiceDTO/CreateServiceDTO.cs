using System.ComponentModel.DataAnnotations;

namespace OteLProjectWebUI.Dtos.ServiceDTO
{
    public class CreateServiceDTO
    {
        [Required(ErrorMessage ="Hizmet ikon linki giriniz")]
        public string? ServiceIcon { get; set; }

        [Required(ErrorMessage ="Hizmet Başlığı Giriniz")]
        [StringLength(100,ErrorMessage ="Hizmet başlığı maksimum 100 karakter olmalı")]
        public string? Title { get; set; }

        [Required(ErrorMessage ="Hizmet Açıklamasını Giriniz")]
        public string? Description { get; set; }
    }
}
