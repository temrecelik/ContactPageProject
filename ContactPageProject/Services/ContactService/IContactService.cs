using ContactPageProject.Models;

namespace ContactPageProject.Services.ContactService
{
    public interface IContactService
    {
        Task<bool> SendMail(MainContactModel mainContactModel);
    }
}
