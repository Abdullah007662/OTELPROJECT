using AutoMapper;
using OteLProjectDtoLayer.Dtos.RoomDto;
using OteLProjectEntityLayer.Concrete;
using System;

namespace OtelWebApi.Mapping
{
    public class AutoMappingConfig:Profile
    {
        //Auto Mapper Paketlerini Kuruyoruz 
        //Bu Sınıf Kullanmamızın Sebebi DTO ve Entity Baglayacagımız bir sınıf olarak seçmemizdir.
        //İlgili AutoMapper Kodları Constructor içinde yazılır
        public AutoMappingConfig()
        {

            //CreateMap<> Benden Neyle neyi Ekleyecegimizi Söylüyor..ReverseMap Eklerse Bu işlemi Tekrar etmesiniz isteriz ama tekrardan kod tekrarına düşmemize engel olur ve bu işlemi kendi otomatik yapar.
            
            CreateMap<RoomAddDto, Room>();
            CreateMap<Room,RoomAddDto>();

            CreateMap<UpdateRoomDto, Room>().ReverseMap();
            

        }
    }
}
