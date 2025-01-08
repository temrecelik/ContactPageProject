using ContactPageProject.Extentions;
using System.ComponentModel.DataAnnotations;

namespace ContactPageProject.Models
{
    public class OtherPersonContactViewModel
    {
        [Required(ErrorMessage = "Ad soyad alanı boş bırakılamaz !")]
        [Display(Name ="Ad Soyad : ")]
        public string otherPersonNameSurname {  get; set; }

		[Required(ErrorMessage = "Mail adresi alanı boş bırakılamaz !")]
		[Display(Name = "Mail Adresi : ")]
		[EmailAddress(ErrorMessage = "Mail adresi birisi@example.com formatında olmalıdır !")]
		public string otherPersonEmail { get; set; }


		[Required(ErrorMessage = "İletişim numarası alanı boş bırakılamaz !")]
        [Display(Name = "İletişim Numarası : ")]
        public string contactPhoneNumber {  get; set; }

        [Required(ErrorMessage = "Mesaj konusu alanı boş bırakılamaz !")]
        [Display(Name = "Mesaj Konusu : ")]
        public string messageSubject { get; set; }

        [Required(ErrorMessage = "Mesaj metni alanı boş bırakılamaz !")]
        [Display(Name = "Mesaj Metni : ")]
        public string MessageText {  get; set; }

        [Display(Name = "Dosya Seç: ")]
        [AllowedExtensions(new[] { ".jpg", ".png", ".pdf", ".docx", ".xlsx" }, ErrorMessage = "Sadece jpg, png, pdf, docx veya xlsx dosya uzantılarına izin verilir.")]
        public IFormFile? formFile { get; set; }

    }
}
