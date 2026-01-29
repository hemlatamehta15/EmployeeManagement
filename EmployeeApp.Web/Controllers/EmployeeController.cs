using EmployeeApp.Application.DTOS;
using EmployeeApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(EmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        public IActionResult Create()
        {
            _logger.LogInformation("Adding new employee");
            return View();
        }

        // POST: Create Employee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeDto model)
        {
            try
            {
                _logger.LogInformation("Adding new employee post method");
                if (ModelState.IsValid)
                {
                    model.CreatedDate = DateTime.Now;
                    await _employeeService.AddAsync(model);
                    _logger.LogInformation("Employee Added successfully");

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating new employees");
            }
            return View(model);
        }
        // Employee List
        public async Task<IActionResult> Index()
        {
            List<EmployeeDto> employees = new List<EmployeeDto>();
            try
            {
                _logger.LogInformation("Fetching employee list");
                employees = await _employeeService.GetEmployees();

                _logger.LogInformation("Employee list fetched successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching employee list");
            }
            return View(employees);
        }

        // Load Edit Modal (Partial View)
        public async Task<IActionResult> Edit(int id)
        {
            EmployeeDto employee = new EmployeeDto();
            try
            {
                _logger.LogInformation("Load Edit employee");
                employee = await _employeeService.GetByIdAsync(id);
                _logger.LogInformation("Fetched employee for edit employee");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching employee for Edit");
            }
            return PartialView("_EmployeeEdit", employee);
        }

        // Save Employee
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeDto model)
        {
            try
            {
                _logger.LogInformation("Post Edit employee");
               // model.CreatedDate = model.CreatedDate;
                await _employeeService.UpdateAsync(model);
                _logger.LogInformation("Employee edited for Edit employee");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while Updating employee for Edit");
            }
            return Json(true);
        }
    }
}