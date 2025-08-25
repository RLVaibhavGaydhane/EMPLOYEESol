using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Portl.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        public int? EmployeId { get; set; }
        [ForeignKey("EmployeId")]
        [ValidateNever]

        public Employee? Employee { get; set; }


    }
}
