using Microsoft.AspNetCore.Mvc.Rendering;

namespace ContactPageProject.Models.SelectLists
{
    public interface ISelectLists
    {
        SelectList GetDepartmentSelectList();
        SelectList RelevantUnitList();
    }
}
