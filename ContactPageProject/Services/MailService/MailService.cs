using ContactPageProject.Models;
using ContactPageProject.OptionModels;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ContactPageProject.Services.MailService
{
    public class MailService :IMailService
    {
        public readonly EmailSettings _emailSettings;

        public MailService(IOptions<EmailSettings> options)
        {
            _emailSettings = options.Value;
        }

        public async Task SendMailForStudents(StudentContactViewModel studentContactViewModel)
        {
            var smptClient = new SmtpClient();
            smptClient.Host = _emailSettings.Host;
            smptClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smptClient.UseDefaultCredentials = false;
            smptClient.Port = 587;
            smptClient.Credentials = new NetworkCredential(_emailSettings.Email, _emailSettings.Password);
            smptClient.EnableSsl = true;

            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_emailSettings.Email);
            List<string> recipients = new();

            //öğrenciler için mesajı alacak mail adresleri
            var subjectEmailMap = new Dictionary<string, List<string>>
            {
                 { "Fen Bilimleri Öğrenci İşleri",    new List<string> { "" } },
                 { "Sağlık Bilimleri Öğrenci İşleri", new List<string> { "" } },
                 { "Sosyal Bilimleri Öğrenci İşleri", new List<string> { "" } },
                 { "Mezuniyet ve Diploma", new List<string> { "" } },
                 { "Yönetim Kurulu", new List<string> { "" } },
                 { "Yazı İşleri", new List<string> { "" } },
                 { "Mali İşler", new List<string> { "" } },
                 { "Enstitü Sekreteri", new List<string> { "" } },
                 { "Diğer Konular", new List<string> { "" } }
            };

            if (subjectEmailMap.TryGetValue(studentContactViewModel.relevantUnit, out var emails))
            {            
                recipients.AddRange(emails);
            }          

            foreach (string recipient in recipients)
            {
                mailMessage.To.Add(recipient);
                mailMessage.CC.Add(recipient);
            }

            mailMessage.Subject = $"{studentContactViewModel.messageSubject}";
            mailMessage.Body = @$"
                                       
				<p>{studentContactViewModel.MessageText}</p> </br>  
				<p><strong>Öğrenci Ad Soyad: </strong>{studentContactViewModel.studentNameSurname}</p>
                <p><strong>Anabilim Dalı: </strong>{studentContactViewModel.department}</p>
                <p><strong>Öğrenci NO: </strong>{studentContactViewModel.studentNumber}</p>
                <p><strong>Mail Adresi: </strong>{studentContactViewModel.StudentEmail}</p>";

			mailMessage.ReplyToList.Add(new MailAddress(studentContactViewModel.StudentEmail));
            mailMessage.IsBodyHtml = true;
     
            if (studentContactViewModel.formFile != null && studentContactViewModel.formFile.Length > 0) {
                var attachmentStream = studentContactViewModel.formFile.OpenReadStream();
                var attachment = new Attachment(attachmentStream, studentContactViewModel.formFile.FileName, studentContactViewModel.formFile.ContentType);
                mailMessage.Attachments.Add(attachment);

            }

            await smptClient.SendMailAsync(mailMessage);
        }

        public async Task SendMailForAcademicStaff(AcademicStaffContactViewModel academicStaffContactViewModel)
        {
            var smptClient = new SmtpClient();
            smptClient.Host = _emailSettings.Host;
            smptClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smptClient.UseDefaultCredentials = false;
            smptClient.Port = 587;
            smptClient.Credentials = new NetworkCredential(_emailSettings.Email, _emailSettings.Password);
            smptClient.EnableSsl = true;

            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_emailSettings.Email);

			List<string> recipients = new();
            //Akedemik Personeller için Mesajı Alacak Mail adresleri
            var subjectEmailMap = new Dictionary<string, List<string>>
            {
                 { "Fen Bilimleri Öğrenci İşleri",    new List<string> { "" } },
                 { "Sağlık Bilimleri Öğrenci İşleri", new List<string> { "" } },
                 { "Sosyal Bilimleri Öğrenci İşleri", new List<string> { "" } },
                 { "Mezuniyet ve Diploma", new List<string> { "" } },
                 { "Yönetim Kurulu", new List<string> { "" } },
                 { "Yazı İşleri", new List<string> { "" } },
                 { "Mali İşler", new List<string> { "" } },
                 { "Enstitü Sekreteri", new List<string> { "" } },
                 { "Diğer Konular", new List<string> { "" } }
            };
      
            if (subjectEmailMap.TryGetValue(academicStaffContactViewModel.relevantUnit, out var emails))
            {                
                recipients.AddRange(emails);
            }

            foreach (string recipient in recipients)
            {
                mailMessage.To.Add(recipient);
                mailMessage.CC.Add(recipient);
            }

            mailMessage.Subject = $"{academicStaffContactViewModel.messageSubject}";
            mailMessage.Body = @$"
                                       
				<p>{academicStaffContactViewModel.MessageText}</p> </br>
				<p><strong>Akedemik Personel Ad Soyad: </strong>{academicStaffContactViewModel.academicStaffNameSurname}</p>
                <p><strong>Anabilim Dalı: </strong>{academicStaffContactViewModel.department}</p>
                <p><strong>Mail Adresi: </strong>{academicStaffContactViewModel.academicStaffEmail}</p>";

            mailMessage.ReplyToList.Add(new MailAddress(academicStaffContactViewModel.academicStaffEmail));
            mailMessage.IsBodyHtml = true;

            if (academicStaffContactViewModel.formFile != null && academicStaffContactViewModel.formFile.Length > 0)
            {
                var attachmentStream = academicStaffContactViewModel.formFile.OpenReadStream(); 
                var attachment = new Attachment(attachmentStream, academicStaffContactViewModel.formFile.FileName, academicStaffContactViewModel.formFile.ContentType);
                mailMessage.Attachments.Add(attachment);
            }
            
            await smptClient.SendMailAsync(mailMessage);
        }

        public async Task SendMailForOtherPerson(OtherPersonContactViewModel otherPersonContactViewModel)
        {
            var smptClient = new SmtpClient();
            smptClient.Host = _emailSettings.Host;
            smptClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smptClient.UseDefaultCredentials = false;
            smptClient.Port = 587;
            smptClient.Credentials = new NetworkCredential(_emailSettings.Email, _emailSettings.Password);
            smptClient.EnableSsl = true;

            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_emailSettings.Email);

            //Diğer Kişiler için mesajı alacak mail adresleri
            string[] recipients = { "" };

            foreach (string recipient in recipients)
            {
                mailMessage.To.Add(recipient);
                mailMessage.CC.Add(recipient);  
            }
            mailMessage.Subject = $"{otherPersonContactViewModel.messageSubject}";
            mailMessage.Body = @$"
                                       
				<p>{otherPersonContactViewModel.MessageText}</p> </br>
				<p><strong> Ad Soyad: </strong>{otherPersonContactViewModel.otherPersonNameSurname}</p>
                <p><strong>İletişim Numarası: </strong>{otherPersonContactViewModel.contactPhoneNumber}</p>
                <p><strong>Mail Adresi: </strong>{otherPersonContactViewModel.otherPersonEmail}</p>";
                          
            mailMessage.ReplyToList.Add(new MailAddress(otherPersonContactViewModel.otherPersonEmail));
            mailMessage.IsBodyHtml = true;

            if (otherPersonContactViewModel.formFile != null && otherPersonContactViewModel.formFile.Length > 0)
            {
                var attachmentStream = otherPersonContactViewModel.formFile.OpenReadStream();
                var attachment = new Attachment(attachmentStream, otherPersonContactViewModel.formFile.FileName, otherPersonContactViewModel.formFile.ContentType);
                mailMessage.Attachments.Add(attachment);

            }

            await smptClient.SendMailAsync(mailMessage);
        }

    }
}
