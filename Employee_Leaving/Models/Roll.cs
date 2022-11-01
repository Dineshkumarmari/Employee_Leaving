using System.ComponentModel.DataAnnotations;

namespace Employee_Leaving.Models
{
    public class Roll
    {
        [Key]
        public int RollId { get; set; }
        public string? RollName { get; set; }

    }
}
