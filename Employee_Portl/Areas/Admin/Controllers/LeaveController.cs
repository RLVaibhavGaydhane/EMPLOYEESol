using Employee_Portl.Data;
using Employee_Portl.Models;
using Employee_Portl.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee_Portl.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LeaveController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeaveController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var leaves = await _context.Leaves.Include(a => a.Employee)
                .ToListAsync();

            return View(leaves);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new LeaveViewModel
            {

                Employees = _context.Employees.ToList(),



                Status = "Pending"

            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveViewModel model)
        {
            if (ModelState.IsValid)
            {

                return Content("Model is not valid.");
            }

            var leave = new Leave
            {
                EmployeeId = model.EmployeeId,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Reason = model.Reason,
                Status = model.Status,

            };

            _context.Leaves.Add(leave);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var leave = await _context.Leaves.FindAsync(id);
            if (leave == null) return NotFound();

            var model = new LeaveViewModel
            {
                Id = leave.Id,
                EmployeeId = leave.EmployeeId,
                StartDate = leave.StartDate,
                EndDate = leave.EndDate,
                Reason = leave.Reason,
                Status = leave.Status,                
                Employees = _context.Employees.ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LeaveViewModel model)
        {

            var leave = await _context.Leaves.FindAsync(model.Id);
            if (leave == null) return NotFound();

            leave.EmployeeId = model.EmployeeId;
            leave.StartDate = model.StartDate;
            leave.EndDate = model.EndDate;
            leave.Reason = model.Reason;
            leave.Status = model.Status;

            _context.Update(leave);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var leave = await _context.Leaves
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (leave == null) return NotFound();

            return View(leave);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Leave leave)
        {
            if (leave == null) return NotFound();

            _context.Leaves.Remove(leave);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }

}




