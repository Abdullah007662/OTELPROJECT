using Microsoft.Extensions.DependencyInjection;
using OteLProjectBusinessLayer.Abstract;
using OteLProjectBusinessLayer.Concrete;
using OteLProjectDataAccessLayer.Abstract;
using OteLProjectDataAccessLayer.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OteLProjectBusinessLayer.Conteiner
{
    public static class Extension
    {
        public static void ConteinerDependencies(this IServiceCollection Services)
        {
            Services.AddScoped<IStaffDal, EfStaffDal>();
            Services.AddScoped<IStaffService, StaffManager>();

            Services.AddScoped<IRoomDal, EfRoomDal>();
            Services.AddScoped<IRoomService, RoomManager>();

            Services.AddScoped<IServiceDal, EfServiceDal>();
            Services.AddScoped<IServiceService, ServiceManager>();

            Services.AddScoped<ITestimonialDal, EfTestimonialDal>();
            Services.AddScoped<ITestimonialService, TestimonialManager>();

            Services.AddScoped<ISubscribeDal, EfSubscribeDal>();
            Services.AddScoped<ISubscribeService, SubscribManager>();

            Services.AddScoped<IAboutDal, EfAboutDal>();
            Services.AddScoped<IAboutService, AboutManager>();

            Services.AddScoped<IBookingDal, EfBookingDal>();
            Services.AddScoped<IBookingService, BookingManager>();

            Services.AddScoped<IGuestDal, EfGuestDal>();
            Services.AddScoped<IGuestService, GuestManager>();

            Services.AddScoped<IContactDal, EfContactDal>();
            Services.AddScoped<IContactService, ContactManager>();

            Services.AddScoped<ISendeMessageDal, EfSendMessage>();
            Services.AddScoped<ISendMesaggeService, SendMessageManager>();

            Services.AddScoped<IMessageCategoryDal, EfMessageCategory>();
            Services.AddScoped<IMessageCategoryService, MessageCategoryManager>();


            Services.AddScoped<IWorkLocationDal, EfWorkLocationDal>();
            Services.AddScoped<IWorkLocationService, WorkLocationManager>();

            Services.AddScoped<IAppUserDal, EfAppUserDal>();
            Services.AddScoped<IAppUserService, AppUserManager>();


        }
    }
}
