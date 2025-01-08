using ContactPageProject.Models;
using ContactPageProject.Services.MailService;

namespace ContactPageProject.Services.ContactService
{
    public class ContactManager :IContactService
    {
        private readonly IMailService _mailService;

        public ContactManager(IMailService mailService)
        {
            _mailService = mailService;
        }

        public async  Task<bool>  SendMail(MainContactModel mainContactModel)
        {

            
                if (mainContactModel.Applicant == "Student")
                {
                    await _mailService.SendMailForStudents(mainContactModel.StudentContactViewModel! );
                    return true;
                }

                if (mainContactModel.Applicant == "AcedemicStaff")
                {
                    await _mailService.SendMailForAcademicStaff(mainContactModel.AcademicStaffContactViewModel!);
                    return true;
                }

                if (mainContactModel.Applicant == "OtherPerson")
                {
                    await _mailService.SendMailForOtherPerson(mainContactModel.OtherPersonContactViewModel!);
                    return true;
                }
                
                return false;
        }
    }
}
