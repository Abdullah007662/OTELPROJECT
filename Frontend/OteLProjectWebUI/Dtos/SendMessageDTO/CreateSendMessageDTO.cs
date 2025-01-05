using System.ComponentModel.DataAnnotations;

namespace OteLProjectWebUI.Dtos.SendMessageDTO
{
    public class CreateSendMessageDTO
    {
        [Required(ErrorMessage = "Alıcı Adı Soyadı Boş Geçilemez")]
        public string? ReceiverName { get; set; }

        [Required(ErrorMessage = "Alıcı Mail Adresi Boş Geçilemez")]
        public string? ReceiverMail { get; set; }

        public string? SenderName { get; set; }

        public string? SenderMail { get; set; }

        [Required(ErrorMessage = "Konu Boş Geçilemez")]
        public string? Title { get; set; }


        [Required(ErrorMessage = "İçerik Boş Geçilemez")]
        public string? Content { get; set; }

        public DateTime? Date { get; set; }
    }
}
