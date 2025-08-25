using Employee_Portl.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Employee_Portl.ViewModel
{
    public class LeaveViewModel
    {
        public int? Id { get; set; }


        [Required(ErrorMessage = "StartDate is required")]
        [DataType(DataType.Date)]
        [Display(Name = " StartDate")]
        public DateOnly StartDate { get; set; }


        [Required(ErrorMessage = "EndDate is required")]
        [DataType(DataType.DateTime)]
        [Display(Name = "EndDate")]

        public DateOnly EndDate { get; set; }

        [Required(ErrorMessage = "please select a Employee")]
        [Display(Name = "Employee")]
        public string Reason { get; set; }

        [Required(ErrorMessage = "Please select a status")]
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Required(ErrorMessage = "please select a Employee")]
        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        public EmployeeViewModel EmployeeVM { get; set; }

        public IEnumerable<Employee>? Employees { get; set; }

    }
}
