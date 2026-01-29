using AutoMapper;
using EmployeeApp.Application.DTOS;
using EmployeeApp.Core.Entities;
using EmployeeApp.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Application.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _repo;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<EmployeeDto>> GetEmployees()
        {
            var data = await _repo.GetAllAsync();
            return _mapper.Map<List<EmployeeDto>>(data);
        }
        public async Task<EmployeeDto> GetByIdAsync(int id)
        {
            var data = await _repo.GetByIdAsync(id);
            return _mapper.Map<EmployeeDto>(data);
        }

        public async Task AddAsync(EmployeeDto employeeDto)
        {
            Employee employee = _mapper.Map<Employee>(employeeDto);
            await _repo.AddAsync(employee);
        }

        public async Task UpdateAsync(EmployeeDto employeeDto)
        {
            Employee employee = _mapper.Map<Employee>(employeeDto);
            await _repo.UpdateAsync(employee);
        }
    }
}
