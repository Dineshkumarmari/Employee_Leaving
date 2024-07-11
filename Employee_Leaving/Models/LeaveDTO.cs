using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Employee_Leaving.Models
{
    public class LeaveDTO
    {
        public int Emp_Id { get; set; }
        public int LeaveType_Id { get; set; }
        public DateTime? StartingDate { get; set; }
        public DateTime? EndingDate { get; set; }
        public int TotalNoDays { get; set; }
        public List<SelectListItem>? Leavetypes { get; set; }
        public List<SelectListItem>? EmpList { get; set; }
    }
}
