using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;
using StringLengthAttribute = System.ComponentModel.DataAnnotations.StringLengthAttribute;

namespace Employee_Leaving.Models
{
    public class Employee
    {
        [Key]
        public int Emp_Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "The name can not be empty")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "The name have minimum 5 and maximum 25 character")]
        public string? Name { get; set; }



        [Unique]
        [Required]
        [MaxLength(100)]
        public string? Email_Id { get; set; }

        [Required]
       [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{8,}", ErrorMessage = "Must contain at least one number and one uppercase and lowercase letter, and at least 8 or more characters")]

        public string? Password { get; set; }

        [Unique]
        [Required]
        public string? PhoneNum { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Gender { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Location { get; set; }

    }
    
}
