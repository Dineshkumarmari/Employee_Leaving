using Employee_Leaving.Models;

namespace Employee_Leaving.Repository
{
    public interface ILeaving
    {
        //Employee
        public IEnumerable<Employee> GetEmployee();
        public Message AddEmployee(Employee emp);
        public Message DeleteEmployee(int id);
        public Employee GetbyId(int id);
        public Employee GetbyEmail(string Email);
        public Message UpdateEmp(Employee emp);

        //Leave
        public IEnumerable<Leave> GetAll();
        public Message AddLeave(Leave lev);
        public Leave Getbyid(int id); 
        public Leave GetbyRemainingDays(Leave lev);
        public Message DeleteLeave(int id);
        public Message AcceptLeave(int id,int Cid);
        public Message RejectLeave(int id, int Cid);
        public IEnumerable<EmployeeLeaveDetails>GetEmployeeLeave(int id);

        //LeaveTypes
        public Leave_Type AddType(Leave_Type LT);
        public Leave_Type GetId(int id);
        public IEnumerable<Leave_Type> GetAllType();
       
    }
   
}
