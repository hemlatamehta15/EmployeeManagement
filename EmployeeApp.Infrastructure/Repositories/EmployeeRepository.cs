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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllAsync()
            => await _context.Employees.ToListAsync();

        public async Task<Employee> GetByIdAsync(int id)
            => await _context.Employees.FindAsync(id);

        public async Task AddAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {            
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}
