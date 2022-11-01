using Employee_Leaving.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;

namespace Employee_Leaving.Repository
{
    public class Repository : ILeaving
    {
        private readonly LeavingDbContext leavingDb;
        public Repository(LeavingDbContext leavingDb)
        {
            this.leavingDb = leavingDb;
        }

        //admin table

        public IEnumerable<Employee> GetEmployee()
        {
            return leavingDb.Employee.ToList();
        }
        public Employee GetbyId(int id)
        {

            var emp = leavingDb.Employee.FirstOrDefault(x => x.Emp_Id == id);
            leavingDb.SaveChanges();
            return emp;
        }
        public Employee GetbyEmail(string Email)
        {

            var emp = leavingDb.Employee.FirstOrDefault(x => x.Email_Id == Email);
            leavingDb.SaveChanges();
            return emp;
        }
        public Message AddEmployee(Employee emp)
        {
            Message msg = new Message();
            try
            {
                var emp3 = leavingDb.Employee.FirstOrDefault(x => x.Emp_Id == emp.Emp_Id);
                var emp1 = leavingDb.Employee.FirstOrDefault(x => x.Email_Id == emp.Email_Id);
                var emp2 = leavingDb.Employee.FirstOrDefault(x => x.PhoneNum == emp.PhoneNum);
                msg.success = false;
                msg.message = "This Employee Already Exists";
                if (emp3 == null && emp1 == null && emp2 == null)
                {
                    leavingDb.Add(emp);
                    leavingDb.SaveChanges();
                    msg.success = true;
                    msg.message = "Employee Added Succesfully";
                    return msg;
                }

                else if (emp1 != null && emp2 != null)
                {
                    Employee empl = GetbyId(emp.Emp_Id);
                    empl.Name = emp.Name;
                    empl.Password = emp.Password;
                    empl.Email_Id = emp.Email_Id;
                    empl.PhoneNum = emp.PhoneNum;
                    empl.Gender = emp.Gender;
                    empl.Age = emp.Age;
                    empl.Location = emp.Location;
                    leavingDb.Update<Employee>(empl);
                    leavingDb.SaveChanges();
                    msg.success = true;
                    msg.message = "Employee Updated Succesfully";

                }
                return msg;
            }
            catch (Exception ex)
            {
                msg.message = ex.Message;
                return msg;
            }
        }

        public Message UpdateEmp(Employee emp)
        {
            Message msg = new Message();
            try
            {
                msg.success = false;
                msg.message = "This employee id not registered";
                var empl = leavingDb.Employee.FirstOrDefault(x => x.Emp_Id == emp.Emp_Id);
                if (empl != null)
                {
                    empl.Name = emp.Name;
                    empl.Password = emp.Password;
                    empl.Email_Id = emp.Email_Id;
                    empl.PhoneNum = emp.PhoneNum;
                    empl.Gender = emp.Gender;
                    empl.Age = emp.Age;
                    empl.Location = emp.Location;
                    leavingDb.Update<Employee>(empl);
                    leavingDb.SaveChanges();
                    msg.message = "Employee Updated Succesfully";
                }
                return msg;
            }

            catch (Exception ex)
            {
                msg.message = ex.Message;
                return msg;
            }
        }

        public Message DeleteEmployee(int id)
        {
            Message msg = new Message();
            try
            {
                msg.success = false;
                msg.message = "This employee id not registered";
                var emp = leavingDb.Employee.FirstOrDefault(x => x.Emp_Id == id);
                var emp1 = leavingDb.Leave.FirstOrDefault(x => x.Emp_Id == id);

                if (emp != null && emp1 == null)
                {
                    leavingDb.Remove(emp);
                    leavingDb.SaveChanges();
                    msg.message = "Employee Deleted Succesfully";
                    msg.success = true;
                    return msg;
                }
                else if (emp1.StartingDate > DateTime.Now || emp1.EndingDate > DateTime.Now)
                {

                    msg.message = " You can't Deleted This Employee..Because This Employee Applied for Leave in Future Date";
                    return msg;
                }
                else
                {
                    msg.message = "This Employee Applied for Leave.. So You can't Delete This Employee ";

                }
                return msg;
            }

            catch (Exception ex)
            {
                msg.message = ex.Message;
                return msg;
            }

        }

        public Message DeleteLeave(int id)
        {
            Message msg = new Message();
            var emp = leavingDb.Leave.FirstOrDefault(x => x.Emp_Id == id);
            if (emp != null)
            {
                leavingDb.Remove(emp);
                leavingDb.SaveChanges();
                msg.success = true;
                msg.message = "Employee Leave Deleted Succesfully";
            }
            return msg;
        }

        public Leave Getbyid(int id)
        {
            var emp = leavingDb.Leave.FirstOrDefault(x => x.Emp_Id == id);
            return emp;
        }
        public Message AddLeave(Leave lev)
        {
            Message msg = new Message();
            var emp = leavingDb.Employee.FirstOrDefault(x => x.Emp_Id == lev.Emp_Id);
            var emp1 = leavingDb.Leave.FirstOrDefault(x => x.Emp_Id == lev.Emp_Id);
            var ep2 = leavingDb.Leave.FirstOrDefault(x => x.LeaveType_Id == lev.LeaveType_Id);
            var emp2 = leavingDb.LeaveTypes.FirstOrDefault(x => x.LeaveType_Id == lev.LeaveType_Id);
            if (lev.TotalNoDays < emp2.TotalDays)
            {
                if (emp1 != null && ep2 != null)
                {
                    var emp3 = leavingDb.Leave.Where(x => x.Emp_Id == lev.Emp_Id).ToList();
                    var ep1 = emp3.Where(x => x.ActionResult == "Accepted").ToList();
                    var ep = ep1.LastOrDefault(x => x.LeaveType_Id == lev.LeaveType_Id);

                    var ep3 = emp3.Where(x => x.ActionResult == "Rejected").ToList();
                    var ep4 = ep3.LastOrDefault(x => x.LeaveType_Id == lev.LeaveType_Id);

                    if (ep.RemainingLeaveDays >= lev.TotalNoDays || ep4.RemainingLeaveDays >= lev.TotalNoDays || lev.StartingDate < lev.EndingDate)
                    {
                        lev.RemainingLeaveDays = emp2.TotalDays;
                        lev.LeaveType_Id = lev.LeaveType_Id;
                        leavingDb.Add(lev);
                        leavingDb.SaveChanges();
                        msg.success = true;
                        msg.message = "Leave Applied successfully";
                        return msg;
                    }
                    else
                    {
                        msg.success = false;
                        msg.message = "You Can't Take  Leave .. Because your  " + emp2.LeaveType + " Total Leave days Limit crossed..";
                        return msg;
                    }
                }
                else
                {
                    lev.RemainingLeaveDays = emp2.TotalDays;
                    leavingDb.Add(lev);
                    leavingDb.SaveChanges();
                    msg.success = true;
                    msg.message = "Leave Applied successfully";
                    return msg;
                }
            }
            msg.success = false;
            msg.message = emp2.LeaveType + "  Total Leave days Limit crossed..";
            return msg;

        }

        public IEnumerable<EmployeeLeaveDetails> GetEmployeeLeave(int id)
        {

            {
                var employeeleave = (from Leave in leavingDb.Leave
                                     join Employee in leavingDb.Employee on Leave.Emp_Id equals Employee.Emp_Id
                                     join leavedetail in leavingDb.LeaveTypes on Leave.LeaveType_Id equals leavedetail.LeaveType_Id
                                     where Leave.Emp_Id == id
                                     select new EmployeeLeaveDetails
                                     {
                                         EmployeeName = Employee.Name,
                                         Leavename = leavedetail.LeaveType,
                                         StartingDate = Leave.StartingDate,
                                         EndingDate = Leave.EndingDate,
                                         TotalNoDays = Leave.TotalNoDays,
                                         ActionResult = Leave.ActionResult,
                                         RemainingLeaveDays = Leave.RemainingLeaveDays,
                                     }).ToList();
                return employeeleave;
            }
        }


        public IEnumerable<EmployeeLeaveDetails> EmployeeLeavedetails()
        {

            {
                var employeeleave = (from Leave in leavingDb.Leave
                                     join Employee in leavingDb.Employee on Leave.Emp_Id equals Employee.Emp_Id
                                     join leavedetail in leavingDb.LeaveTypes on Leave.LeaveType_Id equals leavedetail.LeaveType_Id
                                     select new EmployeeLeaveDetails
                                     {
                                         LeaveTypeId = Leave.LeaveType_Id,
                                         Emp_Id = Employee.Emp_Id,
                                         LeaveId = Leave.Leave_Id,
                                         EmployeeName = Employee.Name,
                                         Leavename = leavedetail.LeaveType,
                                         StartingDate = Leave.StartingDate,
                                         EndingDate = Leave.EndingDate,
                                         TotalNoDays = Leave.TotalNoDays,
                                         ActionResult = Leave.ActionResult,
                                         RemainingLeaveDays = Leave.RemainingLeaveDays,
                                     }).ToList();
                return employeeleave;
            }
        }
        public Leave GetbyRemainingDays(Leave lev)
        {
            Message msg = new Message();
            var emp1 = leavingDb.Leave.FirstOrDefault(x => x.Emp_Id == lev.Emp_Id);
            if (emp1 != null)
            {
                if (lev.StartingDate < lev.EndingDate && emp1.RemainingLeaveDays >= lev.TotalNoDays)
                {
                    leavingDb.Add(lev);
                    leavingDb.SaveChanges();
                    return lev;
                }
            }
            leavingDb.Add(lev);
            leavingDb.SaveChanges();
            return lev;
        }
        public IEnumerable<Leave> GetAll()
        {
            return leavingDb.Leave.ToList();
        }

        //LeaveTypes Table

        public Leave_Type AddType(Leave_Type LT)
        {
            var Lt = leavingDb.LeaveTypes.FirstOrDefault(x => x.LeaveType == LT.LeaveType);
            if (Lt == null)
            {
                leavingDb.LeaveTypes.Add(LT);
                leavingDb.SaveChanges();
                return LT;
            }
            throw new Exception("This Leave Type Already Exists");
        }
        public Leave_Type GetId(int id)
        {
            var emp = leavingDb.LeaveTypes.FirstOrDefault(x => x.LeaveType_Id == id);
            return emp;
        }
        public IEnumerable<Leave_Type> GetAllType()
        {
            return leavingDb.LeaveTypes.ToList();
        }
        public Message AcceptLeave(int id, int Cid)
        {
            Message msg = new Message();
            var emp3 = leavingDb.Leave.Where(x => x.Emp_Id == id).ToList();
            var ep1 = emp3.Where(x => x.ActionResult == "Accepted").ToList();
            var ep = ep1.LastOrDefault(x => x.LeaveType_Id == Cid);

            var newemp = leavingDb.Leave.Where(x => x.ActionResult == "Pending").ToList();
            var emp = newemp.LastOrDefault(x => x.Emp_Id == id);

            if (ep == null && emp.RemainingLeaveDays - emp.TotalNoDays >= 0)
            {
                emp.ActionResult = "Accepted";
                emp.RemainingLeaveDays = emp.RemainingLeaveDays - emp.TotalNoDays;
                leavingDb.SaveChanges();
                msg.success = true;
                msg.message = "Leave Accepted Succesfully";
                return msg;
            }

            if (ep != null && ep.RemainingLeaveDays - emp.TotalNoDays >= 0)
            {
                emp.ActionResult = "Accepted";
                emp.RemainingLeaveDays = ep.RemainingLeaveDays - emp.TotalNoDays;
                leavingDb.SaveChanges();
                msg.success = true;
                msg.message = "Leave Accepted Succesfully";
                return msg;
            }
            return msg;

        }

        public Message RejectLeave(int id, int Cid)
        {
            Message msg = new Message();
            var emp3 = leavingDb.Leave.Where(x => x.Emp_Id == id).ToList();
            var ep1 = emp3.Where(x => x.ActionResult == "Accepted").ToList();
            var ep = ep1.LastOrDefault(x => x.LeaveType_Id == Cid);

            var emp4 = leavingDb.Leave.Where(x => x.Emp_Id == id).ToList();
            var ep2 = emp4.Where(x => x.ActionResult == "Rejected").ToList();
            var ep3 = ep2.LastOrDefault(x => x.LeaveType_Id == Cid);

            var newemp = leavingDb.Leave.Where(x => x.ActionResult == "Pending").ToList();
            var emp = newemp.LastOrDefault(x => x.LeaveType_Id == Cid);

            if (emp != null)
            {
                emp.ActionResult = "Rejected";
                emp.RemainingLeaveDays = emp.RemainingLeaveDays;
                leavingDb.SaveChanges();
                msg.success = true;
                msg.message = "Leave Rejected Succesfully";
                return msg;
            }
            if (ep != null && DateTime.Now <= ep.EndingDate && DateTime.Now <= ep.StartingDate)
            {
                ep.ActionResult = "Rejected";
                ep.RemainingLeaveDays = ep.RemainingLeaveDays + ep.TotalNoDays;
                leavingDb.SaveChanges();
                msg.success = true;
                msg.message = "Leave Rejected Succesfully";
                return msg;
            }
            msg.message = "You can't reject this Id ..";
            return msg;
        }
        public IEnumerable<Roll> Types()
        {
            return leavingDb.Roll.ToList();
        }

        public LoginDTO loginbyid(string number, string password)
        {
            var employee = (from Employee in leavingDb.Employee



                            join Roll in leavingDb.Roll on Employee.RollId equals Roll.RollId
                            where Employee.Password == password && Employee.Email_Id == number
                            select new LoginDTO()
                            {
                                Email_Id = Employee.Email_Id,
                                Password = Employee.Password,
                                Emp_Id = Employee.Emp_Id,
                                Name = Employee.Name,
                                RollId = Roll.RollId,
                                RollName = Roll.RollName,


                            }).FirstOrDefault();



            return employee;
        }

    }

    

}