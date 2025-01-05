using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using OteLProjectWebUI.Models.Mail;

namespace OteLProjectWebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminMailViewModel model)
        {
            MimeMessage mimeMessage = new MimeMessage();//İlk Başta İndirdigimiz Paketten Bir nesne oluşturuyoruz ki içindeki propertylere methodlara field lara erişim saglayabilelim.
            //Sonra bunun içindeki methodlara atamalar gerçekleştiriyoruz.

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Hotelier Api Admin", "kcdmirapo96@gmail.com");//2 ADet parametre alıyro 1. mail kim tarafından gönderildigi 2. Mail i Gönderen adres ne oldugunu yazıyoruz.
            mimeMessage.From.Add(mailboxAddressFrom);//Kimdenn oldugu kısım


            MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.ReceiverMail);//Kime Olucagı
            mimeMessage.To.Add(mailboxAddressTo);


            var bodybuilder = new BodyBuilder();// Mesajın İçeriği 
            bodybuilder.TextBody = model.Body;
            mimeMessage.Body = bodybuilder.ToMessageBody();

            mimeMessage.Subject = model.Subject;//Başlık Veya Konu Kısmı

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);//Burada baglantıyı acıyoruz ve ussl almıyrouz 
            client.Authenticate("kcdmirapo96@gmail.com", "oauifwpqhjjgrzgn");//Şifreye Ait anahtar degeri alacagız.
            client.Send(mimeMessage);
            client.Disconnect(true);
            ////smtp hatası döndü en başta 
            ///



            //Gönderilen Mailin Veri Tabanına Kayıt Edilmesini yapacagız.

            return View();
        }
    }
}
