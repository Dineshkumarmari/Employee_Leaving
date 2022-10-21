using Employee_Leaving.Models;
using Employee_Leaving.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace User.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILeaving _ad;
       
        public HomeController(ILogger<HomeController> logger, ILeaving admin)
        {
            _logger = logger;
            _ad = admin;
        }

        public IActionResult Index()
        {
            var obj = _ad.GetAll();
            return View(obj);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult LeaveApply()
        {
            LeaveDTO types = new LeaveDTO();
            var namelist = _ad.GetEmployee().ToList();
            types.EmpList = new List<SelectListItem>();
            types.EmpList.Add(new SelectListItem() { Value = "0", Text = "Select Name" });
            types.EmpList.AddRange(
            _ad.GetEmployee().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Emp_Id.ToString(),
            }));
            var Typelist = _ad.GetAllType().ToList();
            types.Leavetypes = new List<SelectListItem>();
            types.Leavetypes.Add(new SelectListItem() { Value = "0", Text = "Select Type" });
            types.Leavetypes.AddRange(
            _ad.GetAllType().Select(a => new SelectListItem
            {
                Text = a.LeaveType,
                Value = a.LeaveType_Id.ToString()
            }));
            return View(types);
        }


        [HttpPost]
        public IActionResult Leave(Leave lev)
        {
            var lev1 = _ad.AddLeave(lev);
            return Json(lev1);
        }
         

            [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployees(Employee emp)
        {

            Message msg = new Message();
            var emp1 = _ad.GetbyEmail(emp.Email_Id);
            if(emp1 == null)
            {
                var obj = _ad.AddEmployee(emp);
                msg.success = true;
                ViewBag.Message = msg.message = "The Employee Added succesfully";
                return View("AddEmployee");
            }
            else
            {
                msg.success = false;
                ViewBag.Message = msg.message = "The Email Id Already exist";
            }
            return View("AddEmployee");
        }

        public IActionResult LeaveDetailsshow(int id)
        {
            var obj = _ad.GetEmployeeLeave(id);
            return View(obj);
        }

        public IActionResult LeaveDetails()
        {
            var obj = _ad.GetAll();
            return View(obj);
        }
        public IActionResult EditEmployee(int Emp_Id)
        {
            var obj = _ad.GetbyId(Emp_Id);
            return View("AddEmployee",obj);
        }

        public IActionResult DeleteEmployee(int Emp_Id)
        {
            var obj = _ad.DeleteEmployee(Emp_Id);
            return Json(obj);
        }

        public IActionResult DeleteLeave(int Emp_Id)
        {
            var obj = _ad.DeleteLeave(Emp_Id);
            return Json(obj);
        }
        public IActionResult EmployeeDetails()
        {
            var obj = _ad.GetEmployee();
            return View(obj);
        }
        [HttpGet]
        public IActionResult Accept(int id, int Cid)
        {
            var accept = _ad.AcceptLeave(id,Cid);
            return Json(accept);
        }

        [HttpGet]
        public IActionResult Reject(int id, int Cid)
        {
            var reject =_ad.RejectLeave(id,Cid);
            return Json(reject);
        }


        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}    
