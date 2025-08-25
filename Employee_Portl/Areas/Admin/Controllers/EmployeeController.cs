using Employee_Portl.Data;
using Employee_Portl.Models;
using Employee_Portl.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee_Portl.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var employees =  _context.Employees.ToList();
            return View(employees);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            DepartmentViewModel departmentViewModel = new DepartmentViewModel();
            departmentViewModel.DptName = await _context.Departments.ToListAsync();

            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            employeeViewModel.DepartmentView = departmentViewModel;
            employeeViewModel.JoinDate = DateTime.Now; // Set default join date to today    

            return View(employeeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel vm)
        {
            Employee employee = new Employee();
            employee.FullName = vm.FullName;
            employee.Email = vm.Email;
            employee.JoinDate = vm.JoinDate;
            employee.DepartmentId = vm.DepartmentView.SelectedDptId;

            await _context.AddAsync(employee);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            DepartmentViewModel departmentViewModel = new DepartmentViewModel();
            departmentViewModel.DptName = await _context.Departments.ToListAsync();
            departmentViewModel.SelectedDptId = employee.DepartmentId;

            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            employeeViewModel.FullName = employee.FullName;
            employeeViewModel.Email = employee.Email;
            employeeViewModel.JoinDate = employee.JoinDate;
            employeeViewModel.DepartmentView = departmentViewModel;

            return View(employeeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeViewModel employeeViewModel)
        {
            var employee = await _context.Employees.FindAsync(employeeViewModel.Id);
            if (employee == null)
            {
                return NotFound();
            }

            employee.FullName = employeeViewModel.FullName;
            employee.Email = employeeViewModel.Email;
            employee.JoinDate = employeeViewModel.JoinDate;
            employee.DepartmentId = employeeViewModel.DepartmentView.SelectedDptId;

            _context.Update(employee);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var employee = await _context.Employees.FindAsync(Id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Employee employee)
        {
            if (employee != null)
            {
                _context.Remove(employee);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }



    }
}
