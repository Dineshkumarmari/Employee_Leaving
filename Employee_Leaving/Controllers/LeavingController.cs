using Employee_Leaving.Models;
using Employee_Leaving.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Employee_Leaving.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeavingController : ControllerBase
    {     
        private readonly ILeaving leave;

        public LeavingController(ILeaving leaving)
        {
            leave = leaving;
        }

        //Employee table

        [HttpGet("/api/Employee/getall")]
        public IActionResult Getemployees()
        {
            try
            {
                var obj = leave.GetEmployee();
                if (obj.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(obj);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("/api/Employee/{id}")]
        public IActionResult GetbyId(int id)
        {
            var emp = leave.GetbyId(id);
            if (emp.Emp_Id != id)
            {
                throw new Exception("This employee id not registered");
            }
            return Ok(emp);
        }

        [HttpPost("/api/Employee/Add")]
        public Message createmployees(Employee emp)
        {
                var employee = leave.AddEmployee(emp);
                return employee;
        }

        [HttpPut("/api/Employee/")]
        public Message update([FromBody] Employee emp)
        {
            var employee = leave.UpdateEmp(emp);
            return employee;
        }

        [HttpDelete("/api/Employee/{id}")]
        public IActionResult DeleteEmp(int id)
        {
            var del = leave.GetbyId(id);
            var del1 = leave.Getbyid(id);
            if (del != null)
            {
                var emp = leave.DeleteEmployee(id);
                return Ok(emp);
            }
            throw new Exception("This employee id not registered");
        }

        //Leave table

        [HttpGet("/api/Leave/{id}")]
        public IActionResult Get(int id)
        {
            var emp= leave.Getbyid(id);
            if (emp != null)
            {
                var emp1 =leave.Getbyid(id);
                 return Ok(emp1);
            }
            throw new Exception("This Emp_id not applied for leave");
        }

        [HttpPost("/api/Leave/Add")]
        public Message Add(Leave lev)
        {
                var obj = leave.AddLeave(lev);
                return obj;
        }

        [HttpGet("/api/Leave/getall")]
        public IActionResult Getall()
        {
            var obj = leave.GetAll();
            if (obj.Count() == 0)
            {
                return NotFound();
            }
            return Ok(obj);
        }
            
        //leaveType Table

        [HttpPost("/api/LeaveType/Add")]
        public IActionResult AddType(Leave_Type LT)
        {
                var obj = leave.AddType(LT);
                return Ok(LT);
        }

        [HttpGet("/api/LeaveType/{id}")]
        public IActionResult GetId(int id)
        {
                var emp = leave.GetId(id);
                return Ok(emp);
        }

        [HttpGet("/api/LeaveType/getall")]
        public IActionResult Getalltypes()
        {
            var obj = leave.GetAllType();
            if (obj.Count() == 0)
            {
                return NotFound();
            }
            return Ok(obj);
  
        }

        [HttpPut("/api/Admin/Accept/{id}")]
        public IActionResult AcceptLeave(int id,int Cid)
        {
              var emp=leave.Getbyid(id);
            if (emp != null)
            {
                var obj = leave.AcceptLeave(id,Cid);
                return Ok(obj);
            }
            throw new Exception("This Emp_Id can not registered");
        }

        [HttpPut("/api/Admin/Reject/{id}")]
        public IActionResult RejectLeave(int id, int Cid)
        {
            var emp = leave.Getbyid(id);
            if (emp != null)
            {
                var obj = leave.RejectLeave(id,Cid);
                return Ok(obj);
            }
            throw new Exception("This Emp_Id can not registered");
        }

    }
}
    

