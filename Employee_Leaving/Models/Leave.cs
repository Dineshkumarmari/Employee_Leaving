using Employee_Leaving.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Leaving.Models
{
    public class Leave
    {
    
        [Key]
        public int Leave_Id { get; set; }

        [ForeignKey("Employee")]
        public int Emp_Id { get; set; }

        [ForeignKey("LeaveTypes")]
        public int LeaveType_Id { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public int TotalNoDays { get; set; }

        [DefaultValue("ActionResult")]
        public string ActionResult { get; set; } = "Pending"; 

        [ForeignKey("LeaveTypes")]
        public int RemainingLeaveDays { get; set; } 
     
    }
}

