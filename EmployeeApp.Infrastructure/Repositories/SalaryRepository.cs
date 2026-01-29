using EmployeeApp.Core.Entities;
using EmployeeApp.Core.Interfaces;
using EmployeeApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Infrastructure.Repositories
{
    public class SalaryRepository : ISalaryRepository
    {
        private readonly AppDbContext _context;

        public SalaryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<EmployeeSalary>> GetCurrentYearSalaryAsync(int employeeId)
        {
            int year = DateTime.Now.Year;

            return await _context.EmployeeSalaries
                .Where(s => s.EmployeeId == employeeId &&
                            s.SalaryDate.Year == year)
                .OrderBy(s => s.SalaryDate)
                .ToListAsync();
        }

        public async Task AddAsync(EmployeeSalary salary)
        {
            _context.EmployeeSalaries.Add(salary);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> SalaryExistsAsync(int employeeId, int year, int month)
        {
            return await _context.EmployeeSalaries.AnyAsync(s =>
                s.EmployeeId == employeeId &&
                s.SalaryDate.Year == year &&
                s.SalaryDate.Month == month);
        }
    }
}
