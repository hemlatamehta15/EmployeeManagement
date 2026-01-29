using EmployeeApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Core.Interfaces
{
    public interface ISalaryRepository
    {
        Task<List<EmployeeSalary>> GetCurrentYearSalaryAsync(int employeeId);
        Task<bool> SalaryExistsAsync(int employeeId, int year, int month); 
        Task AddAsync(EmployeeSalary salary);
    }
}
