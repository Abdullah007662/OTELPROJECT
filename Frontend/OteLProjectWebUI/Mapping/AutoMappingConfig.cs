using AutoMapper;
using OteLProjectEntityLayer.Concrete;
using OteLProjectWebUI.Dtos.AboutDTO;
using OteLProjectWebUI.Dtos.AppUserDTO;
using OteLProjectWebUI.Dtos.BookingDTO;
using OteLProjectWebUI.Dtos.GuestDTO;
using OteLProjectWebUI.Dtos.LoginDTO;
using OteLProjectWebUI.Dtos.MessageCategoryDTO;
using OteLProjectWebUI.Dtos.RegisterDTO;
using OteLProjectWebUI.Dtos.SendMessageDTO;
using OteLProjectWebUI.Dtos.ServiceDTO;
using OteLProjectWebUI.Dtos.StaffDTO;
using OteLProjectWebUI.Dtos.SubcribeDTO;

namespace OteLProjectWebUI.Mapping
{
    public class AutoMappingConfig:Profile
    {
        public AutoMappingConfig()
        {
            CreateMap<ResultServiceDTO, Service>().ReverseMap();
            CreateMap<UpdateServiceDTO, Service>().ReverseMap();
            CreateMap<CreateServiceDTO, Service>().ReverseMap();


            CreateMap<CreateNewUserDTO, AppUser>().ReverseMap();
            CreateMap<LoginUserDTO, AppUser>().ReverseMap();


            CreateMap<ResultAboutDTO, About>().ReverseMap();
            CreateMap<UpdateAboutDTO, About>().ReverseMap();


            CreateMap<ResultStaffDTO, Staff>().ReverseMap();

            CreateMap<CreateSubscribeDTO, Subscribe>().ReverseMap();

            CreateMap<CreateBookingDTO, Booking>().ReverseMap();
            CreateMap<ResultBookingDTO, Booking>().ReverseMap();
            CreateMap<ApprovedResevationDTO, Booking>().ReverseMap();



            CreateMap<CreateGuestDTO, Guest>().ReverseMap();
            CreateMap<UpdateGuestDTO, Guest>().ReverseMap();

            CreateMap<CreateSendMessageDTO, SendMessage>().ReverseMap();

            CreateMap<ResultMessageCategoryDTO, Contact>().ReverseMap();


            CreateMap<ResultAppUserDTO, AppUser>().ReverseMap();

            CreateMap<ResultLast4StaffDTO, Staff>().ReverseMap();
        }
    }
}
