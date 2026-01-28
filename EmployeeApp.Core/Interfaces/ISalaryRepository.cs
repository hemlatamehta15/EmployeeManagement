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
   //     Task<List<EmployeeSalary>> GetCurrentYearSalary(int employeeId);
        Task AddAsync(EmployeeSalary salary);
    }
}
