using Employee_Leaving.Models;
using Employee_Leaving.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Security.Claims;
using System.Security.Policy;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        public IActionResult Index()
        {
             return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Admin()
        {
            return View();
        }
        [Authorize]
        public IActionResult LeaveList()
        {
            var obj = _ad.EmployeeLeavedetails();
            return View(obj);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Admin", "Home");
        }
        [Authorize]
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

        [Authorize]
        [HttpPost]
        public IActionResult Leave(Leave lev)
        {
            var lev1 = _ad.AddLeave(lev);
            return Json(lev1);
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddEmployee()
        {
            LoginDTO types = new LoginDTO();
            var namelist = _ad.Types().ToList();
            types.RollType = new List<SelectListItem>();
            types.RollType.Add(new SelectListItem() { Value = "0", Text = "Select Roll" });
            types.RollType.AddRange(
            _ad.Types().Select(a => new SelectListItem
            {
                Text = a.RollName,
                Value = a.RollId.ToString(),
            }));
            return View(types);
        }
    
        [HttpPost]
        public IActionResult AddEmployees(Employee emp)
        {  
                var obj = _ad.AddEmployee(emp);
                return Json(obj);
   
        }
        [Authorize]
        public IActionResult LeaveDetailsshow(int id)
        {
            var obj = _ad.GetEmployeeLeave(id);
            return View(obj);
        }
        [Authorize]
        public IActionResult LeaveDetails()
        {
            var obj = _ad.EmployeeLeavedetails();
            return View(obj);
        }
        [Authorize]
        public IActionResult EditEmployee(int Emp_Id)
        {
            var obj = _ad.GetbyId(Emp_Id);
            return View("AddEmployee",obj);
        }
        [Authorize]
        public IActionResult DeleteEmployee(int Emp_Id)
        {
            var obj = _ad.DeleteEmployee(Emp_Id);
            return Json(obj);
        }
        [Authorize]
        public IActionResult DeleteLeave(int Emp_Id)
        {
            var obj = _ad.DeleteLeave(Emp_Id);
            return Json(obj);
        }
        [Authorize]
        public IActionResult EmployeeDetails()
        {
            var obj = _ad.GetEmployee();
            return View(obj);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Accept(int id,int Cid)
        {
            var accept = _ad.AcceptLeave(id,Cid);
            return Json(accept);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Reject(int id,int Cid)
        {
            var reject =_ad.RejectLeave(id,Cid);
            return Json(reject);
        }
       

        [HttpPost]
        public async Task<IActionResult> Admin(LoginDTO login)
        {
            var user = _ad.loginbyid(login.Email_Id, login.Password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier , user.Emp_Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Email_Id),
                    new Claim(ClaimTypes.Role, user.RollName)

              };
                var claimsIdentity = new ClaimsIdentity(claims, "Admin");

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return Redirect(login.ReturnUrl == null ? "/Home/Index" : login.ReturnUrl);
             
               
            }
            else
                return View(login);
        }


        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}    
