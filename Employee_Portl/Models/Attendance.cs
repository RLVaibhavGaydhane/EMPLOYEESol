using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Portl.Models
{
    public class Attendance
    {
        public int Id { get; set; }              

        public int EmployeeId { get; set; }     

        public DateTime Date { get; set; }       

        public TimeSpan? CheckIn { get; set; }  

        public TimeSpan? CheckOut { get; set; }

       
        public Employee Employee { get; set; }
    }
}
