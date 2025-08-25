using Employee_Portl.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Employee_Portl.ViewModel
{
    public class AttendanceViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = " Date is required")]
        [DataType(DataType.Date)]
        [Display(Name = " Date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "CheckIn is required")]
        [DataType(DataType.DateTime)]
        [Display(Name = "CheckIn")]

        public TimeSpan CheckIn { get; set; }

        [Required(ErrorMessage = "CheckOut is required")]
        [DataType(DataType.DateTime)]
        [Display(Name = "CheckOut")]
        public TimeSpan CheckOut { get; set; }

        [Required(ErrorMessage = "please select a Employee")]
        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        public EmployeeViewModel  EmployeeVM { get; set; }

        public IEnumerable<SelectListItem>? Employees { get; set; }
    }
}
