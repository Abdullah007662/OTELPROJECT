﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OteLProjectDtoLayer.Dtos.RoomDto
{
    public class UpdateRoomDto
    {
        public int RoomID { get; set; }

        [Required(ErrorMessage = "Lütfen Oda Numarasını Yazınız")]
        public string? RoomNumber { get; set; }

        [Required(ErrorMessage = "Lütfen Oda Görseli Giriniz")]
        public string? RoomCoverImage { get; set; }

        [Required(ErrorMessage = "Lütfen Fiyat Bilgisi Giriniz")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Lütfen Oda Başlığı Bilgisi Giriniz")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Lütfen Yatak Sayısı  Giriniz")]
        public string? BedCount { get; set; }

        [Required(ErrorMessage = "Lütfen Banyo Sayısı  Giriniz")]
        public string? BathCount { get; set; }
        public string? Wifi { get; set; }

        [Required(ErrorMessage = "Lütfen Açıklamayı Yazınız")]
        [StringLength(100,ErrorMessage ="Lütfen 100 Karakter Veri Girişi Yapınız")]
        public string? Description { get; set; }
    }
}
