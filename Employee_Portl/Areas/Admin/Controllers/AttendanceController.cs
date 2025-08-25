using Employee_Portl.Data;
using Employee_Portl.Models;
using Employee_Portl.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Employee_Portl.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AttendanceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttendanceController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task <IActionResult> Index()
        {
            var attendances = await _context.Attendances.Include(a => a.Employee)
                .ToListAsync();

            return View(attendances);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new AttendanceViewModel
            {
                Date = DateTime.Now,
                Employees = _context.Employees
                    .Select(e => new SelectListItem
                    {
                        Value = e.Id.ToString(),
                        Text = e.FullName
                    })
                    .ToList()
            };

            return View(model);
        }
       


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AttendanceViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                return Content("Model is not valid.");
            }

            var attendance = new Attendance
            {
                EmployeeId = model.EmployeeId,
                Date = model.Date.Date,     
                CheckIn = model.CheckIn,
                CheckOut = model.CheckOut
            };

            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance == null) return NotFound();

            var model = new AttendanceViewModel
            {
                Id = attendance.Id,
                EmployeeId = attendance.EmployeeId,
                Date = attendance.Date,
                CheckIn = attendance.CheckIn ?? TimeSpan.Zero,
                CheckOut = attendance.CheckOut ?? TimeSpan.Zero,
                Employees = _context.Employees
                    .Select(e => new SelectListItem
                    {
                        Value = e.Id.ToString(),
                        Text = e.FullName
                    }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AttendanceViewModel model)
        {
            
            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance == null) return NotFound();

            attendance.EmployeeId = model.EmployeeId;
            attendance.Date = model.Date;
            attendance.CheckIn = model.CheckIn;
            attendance.CheckOut = model.CheckOut;

            _context.Update(attendance);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var attendance = await _context.Attendances
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (attendance == null) return NotFound();

            return View(attendance);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Attendance attendance)
        {
            if (attendance == null) return NotFound();

            _context.Attendances.Remove(attendance);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }

}




