using ContactPageProject.Models;

namespace ContactPageProject.Services.MailService
{
    public interface IMailService
    {
        Task SendMailForStudents(StudentContactViewModel studentContactViewModel);
        Task SendMailForOtherPerson(OtherPersonContactViewModel otherPersonContactViewModel );
        Task SendMailForAcademicStaff(AcademicStaffContactViewModel acedemicStaffContactViewModel);
    }
}
