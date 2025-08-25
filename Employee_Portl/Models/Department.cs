using System.ComponentModel.DataAnnotations;

namespace Employee_Portl.Models
{
    public class Department
    {
        public int? Id { get; set; }

        [Required]
        [Display(Name = "Department Name")]
        public string Name { get; set; }
    }
}
