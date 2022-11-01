using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Employee_Leaving.Models
{
    public class LoginDTO
    {
        public int Emp_Id { get; set; }
        public int RollId { get; set; }
        public string? Name { get; set; }
        public string? Email_Id { get; set; }
        public string? Password { get; set; }

        public string? PhoneNum { get; set; }

        public string? Gender { get; set; }

        public int Age { get; set; }

        public string? Location { get; set; }
        public string RollName { get; set; }
        public string ReturnUrl { get; set; }
        public List<SelectListItem> RollType { get; set; }

    }
}
