using EmployeeApp.Application.DTOS;
using EmployeeApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Web.Controllers
{
    public class EmployeeSalaryController : Controller
    {
        private readonly EmployeeSalaryService _salaryService;
        private readonly ILogger<EmployeeSalaryController> _logger;

        public EmployeeSalaryController(EmployeeSalaryService salaryService, ILogger<EmployeeSalaryController> logger)
        {
            _salaryService = salaryService;
            _logger = logger;
        }
        // GET: Add Salary
        public IActionResult AddSalary(int employeeId)
        {
            var model = new EmployeeSalaryDto
            {
                EmployeeId = employeeId,
                SalaryDate = DateTime.Today
            };

            return View(model);
        }

        // POST: Add Salary
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSalary(EmployeeSalaryDto model)
        {
            if (!ModelState.IsValid)
                return View(model);
            int year = model.SalaryDate.Year;
            int month = model.SalaryDate.Month;

            bool exists = await _salaryService
                .SalaryExistsAsync(model.EmployeeId, year, month);

            if (exists)
            {
                ModelState.AddModelError(
                    "",
                    "Salary for this employee and month already exists."
                );
                return View(model);
            }

            await _salaryService.AddAsync(model);

            return RedirectToAction("Index", "Employee");
            
        }
        // Load salary modal (Partial View)
        public async Task<IActionResult> CurrentYearSalary(int employeeId)
        {
            var salaries = await _salaryService
                .GetCurrentYearSalaryAsync(employeeId);

            return PartialView("_EmployeeSalaryList", salaries);
        }
    }
}
