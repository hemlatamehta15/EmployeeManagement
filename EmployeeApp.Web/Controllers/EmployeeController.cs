using EmployeeApp.Application.Services;
using EmployeeApp.Core.Entities;
using EmployeeApp.Core.Interfaces;
using EmployeeApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Create Employee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedDate = DateTime.Now;
                    await _employeeRepository.AddAsync(model);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

            }
            return View(model);
        }
        // Employee List
        public async Task<IActionResult> Index()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                employees = await _employeeRepository.GetAllAsync();
            }
            catch (Exception ex)
            {

            }
            return View(employees);
        }

        // Load Edit Modal (Partial View)
        public async Task<IActionResult> Edit(int id)
        {
            Employee employee = new Employee();
            try
            {
                employee = await _employeeRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {

            }
            return PartialView("_EmployeeEdit", employee);
        }

        // Save Employee
        [HttpPost]
        public async Task<IActionResult> Edit(Employee model)
        {
            try
            {
                model.CreatedDate = model.CreatedDate;
                await _employeeRepository.UpdateAsync(model);
            }
            catch (Exception ex)
            {

            }
            return Json(true);
        }


    }
}