using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Leaving.Models
{
    public class Leave_Type
    {
        [Key]
     public int LeaveType_Id { get; set; }
     public string? LeaveType { get; set; }
     public int TotalDays { get; set; }

   // Azure Test PipeLine
    }
}
