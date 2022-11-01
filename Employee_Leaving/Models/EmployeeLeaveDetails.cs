using System.ComponentModel;

namespace Employee_Leaving.Models
{
    public class EmployeeLeaveDetails
    {
        public int LeaveId { get; set; }
        public int LeaveTypeId { get; set; }
        public int Emp_Id { get; set; }
        public string EmployeeName { get; set; }
        public string Leavename { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public int TotalNoDays { get; set; }
        public string ActionResult { get; set; }
        public int RemainingLeaveDays { get; set; }
    }
}