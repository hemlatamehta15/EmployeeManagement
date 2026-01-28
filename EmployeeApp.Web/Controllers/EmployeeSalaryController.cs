using EmployeeApp.Application.DTOS;
using EmployeeApp.Core.Entities;
using EmployeeApp.Core.Interfaces;
using EmployeeApp.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Web.Controllers
{
    public class EmployeeSalaryController : Controller
    {
        private readonly ISalaryRepository _salaryRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeSalaryController(IEmployeeRepository employeeRepository, ISalaryRepository salaryRepository)
        {
            _employeeRepository = employeeRepository;
            _salaryRepository = salaryRepository;
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
            var salary = new EmployeeSalary
            {
                EmployeeId = model.EmployeeId,
                SalaryDate = model.SalaryDate,
                Amount = model.Amount,
                CreatedDate = DateTime.Now
            };

            await _salaryRepository.AddAsync(salary);

            return RedirectToAction("Index", "Employee");
            
        }
    }
}
