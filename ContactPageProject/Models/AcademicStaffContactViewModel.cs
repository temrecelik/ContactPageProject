
using ContactPageProject.Extentions;
using System.ComponentModel.DataAnnotations;

namespace ContactPageProject.Models
{
    public class AcademicStaffContactViewModel
    {
        [Required(ErrorMessage ="Ad soyad alanı boş bırakılamaz !")]
        [Display(Name = "Ad Soyad : ")]
        public string academicStaffNameSurname { get; set; }

		[Required(ErrorMessage = "Mail adresi alanı boş bırakılamaz !")]
		[Display(Name = "Mail Adresi : ")]
		[EmailAddress(ErrorMessage = "Mail adresi birisi@example.com formatında olmalıdır !")]
		public string academicStaffEmail { get; set; }

		[Required(ErrorMessage = "Anabilim dalı alanı boş bırakılamaz !")]
        [Display(Name = "Anabilim Dalı : ")]
        public string department { get; set; }

        [Required(ErrorMessage = "İlgili birim alanı boş bırakılamaz !")]
        [Display(Name = "İlgili Birim : ")]
        public string relevantUnit { get; set; }

        [Required(ErrorMessage = "Mesaj konusu alanı boş bırakılamaz !")]
        [Display(Name = "Mesaj Konusu : ")]
        public string messageSubject { get; set; }

        [Required(ErrorMessage = "Mesaj metni alanı boş bırakılamaz !")]
        [Display(Name = "Mesaj Metni : ")]
        public string MessageText { get; set; }

        [Display(Name = "Dosya Seç: ")]
        [AllowedExtensions(new[] { ".jpg", ".png", ".pdf", ".docx", ".xlsx" }, ErrorMessage = "Sadece jpg, png, pdf, docx veya xlsx dosya uzantılarına izin verilir.")]
        public IFormFile? formFile { get; set; }
      

    }
}
