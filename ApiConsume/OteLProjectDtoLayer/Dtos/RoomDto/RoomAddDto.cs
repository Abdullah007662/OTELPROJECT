using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OteLProjectDtoLayer.Dtos.RoomDto
{
    public class RoomAddDto
        //RoomAddDto Eklemek İçin Bazı attributleri Kullanıyoruz genelde dataannatasionlarda oldugu gibi Required(Gerekli/Zorunlu) 
    {
        // Birinci Yöntem DataAnnotations İle Dto Ekleme Yani Verileri ViewModel Gibi Arka planda Karsılama 
        //Bu işlem FluentValidasyonu kullanarakta yapılabilir amma ve lakin şuan 1. yöntem olarak dto yu arka planda bu şekilde karşılıyoruz
        // Bunun güvenlik açıgı işe veri arka plana yani server a gelip dogrulanıp geri kullanıcıya deger dönülmesidir bu genelde önerilmez 
        // Eğer ki bunu yapacak olursan Frontend kısmındada Bir javascript ile validasyon yapmak zorundayız ki kötü kullanıcılar server 'a kolay bir  şekilde erişemesin.
        [Required(ErrorMessage ="Lütfen Oda Numarasını Yazınız")]
        public string? RoomNumber { get; set; }
        public string? RoomCoverImage { get; set; }

        [Required(ErrorMessage ="Lütfen Fiyat Bilgisi Giriniz")]
        public int Price { get; set; }
        
        [Required(ErrorMessage = "Lütfen Oda Başlığı Bilgisi Giriniz")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Lütfen Yatak Sayısı  Giriniz")]
        public string? BedCount { get; set; }

        [Required(ErrorMessage = "Lütfen Banyo Sayısı  Giriniz")]
        public string? BathCount { get; set; }
        public string? Wifi { get; set; }
        public string? Description { get; set; }
    }
}
