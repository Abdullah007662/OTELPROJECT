using System.ComponentModel.DataAnnotations;

namespace OteLProjectWebUI.Dtos.ServiceDTO
{
    public class UpdateServiceDTO
    {
        public int ServiceID { get; set; }

        [Required(ErrorMessage = "Hizmet ikon linki giriniz")]
        public string? ServiceIcon { get; set; }

        [Required(ErrorMessage = "Hizmet Başlığı Giriniz")]
        [StringLength(100, ErrorMessage = "Hizmet başlığı maksimum 100 karakter olmalı")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Hizmet Açıklamasını Giriniz")]
        [StringLength(500, ErrorMessage = "Hizmet Açıklaması maksimum 500 karakter olmalı")]
        public string? Description { get; set; }
    }
}
