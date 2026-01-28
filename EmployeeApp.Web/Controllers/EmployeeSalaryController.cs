using EmployeeApp.Core.Entities;
using EmployeeApp.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Web.Controllers
{
    public class EmployeeSalaryController : Controller
    {
        private readonly ISalaryRepository _salaryRepository;

        public EmployeeSalaryController(ISalaryRepository salaryRepository)
        {
            _salaryRepository = salaryRepository;
        }
        // GET: Add Salary
        public IActionResult AddSalary(int employeeId)
        {
            var model = new EmployeeSalary
            {
                EmployeeId = employeeId,
                SalaryDate = DateTime.Today
            };

            return View(model);
        }

        // POST: Add Salary
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSalary(EmployeeSalary model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                await _salaryRepository.AddAsync(model);

                return RedirectToAction("Index", "Employee");
            }

            return View(model);
        }
    }
}
