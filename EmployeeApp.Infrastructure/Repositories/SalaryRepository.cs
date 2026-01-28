using EmployeeApp.Core.Entities;
using EmployeeApp.Core.Interfaces;
using EmployeeApp.Infrastructure.Data;
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

        public async Task AddAsync(EmployeeSalary salary)
        {
            _context.EmployeeSalaries.Add(salary);
            await _context.SaveChangesAsync();
        }
    }
}
