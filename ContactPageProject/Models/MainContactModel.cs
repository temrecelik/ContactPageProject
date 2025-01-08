namespace ContactPageProject.Models
{
    public class MainContactModel
    {
       public AcademicStaffContactViewModel? AcademicStaffContactViewModel { get; set; }
       public OtherPersonContactViewModel? OtherPersonContactViewModel {  get; set; }    
       public StudentContactViewModel? StudentContactViewModel { get; set; }
       public string Applicant { get; set; } = null!;  
    }
}
