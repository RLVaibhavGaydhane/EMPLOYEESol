using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Portl.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Email { get; set; }

        public DateTime JoinDate { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public ICollection<Attendance> Attendances { get; set; }

        public ICollection<Leave> Leaves { get; set; }

        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser? ApplicationUser { get; set; }



    }
}
