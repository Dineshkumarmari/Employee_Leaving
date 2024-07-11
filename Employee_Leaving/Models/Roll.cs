using System.ComponentModel.DataAnnotations;

namespace Employee_Leaving.Models
{
    public class Roll
    {
        //Azure Testing

        [Key]
        public int RollId { get; set; }
        public string? RollName { get; set; }

    }
}
