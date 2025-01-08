using ContactPageProject.Models;

using ContactPageProject.Models.SelectLists;
using ContactPageProject.Services.ContactService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ContactPageProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly ISelectLists _selectLists;

        public ContactController(IContactService contactService, ISelectLists selectLists)
        {
            _contactService = contactService;
            _selectLists = selectLists;
        }

        public IActionResult Index()
        {    
            ViewBag.DepartmentList = _selectLists.GetDepartmentSelectList();
            ViewBag.RelevantUnitList = _selectLists.RelevantUnitList();
      
            return View();
           
        }

        [HttpPost]
        public async Task<IActionResult> Index(MainContactModel request)
        {
            ViewBag.DepartmentList = _selectLists.GetDepartmentSelectList();
            ViewBag.RelevantUnitList = _selectLists.RelevantUnitList();
            TempData["Applicant"] = request.Applicant;

            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _contactService.SendMail(request);

            if (result == true)
            {
                TempData["SuccessMessage"] = "Mesajınız ilgili birime iletilmiştir.";
                return RedirectToAction("Index");
            }
            else
            {         
                ModelState.AddModelError(string.Empty, "Bir hata oluştu lütfen tekrar deneyiniz.");
                return View();
            }        
        }

    }

} 

