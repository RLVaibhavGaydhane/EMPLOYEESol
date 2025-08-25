using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Portl.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        public IActionResult AdminDashboard()
        {
            return View();
        }

        public IActionResult HRDashboard()
        {
            return View();
        }

        public IActionResult ManagerDashboard()
        {
            return View();
        }

        public IActionResult EmployeeDashboard()
        {
            return View();
        }

        public IActionResult UserDashboard()
        {
            return View();
        }
    }
}
