using System.ComponentModel.DataAnnotations;

namespace Employee_Portl.Models
{
    public class Leave
    {
        public int Id { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }

        public Employee Employee { get; set; }

    }
}
