using AutoMapper;
using Entities.Database_Context;
using Entities.DTO.Request;
using Entities.Models.EmployeeModels;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Employee?> AddNewEmployee(EmployeeRequestDto employeeRequest)
        {
            var employee = _mapper.Map<Employee>(employeeRequest);

            try
            {
                await _context.Employees.AddAsync(employee);

                await _context.SaveChangesAsync();

                employee = _mapper.Map<Employee>(employee);

                return employee;
            }
            catch(Exception e)
            {
                return null;
            }

        }

        public async Task<bool> DeleteEmployee(Guid employeeId)
        {
            var employee = await _context.Employees
                .SingleOrDefaultAsync(e => e.EmployeeId == employeeId);

            if (employee is null)
            {
                return false;
            }

            _context.Employees.Remove(employee);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Employee?> GetEmployee(Guid employeeId)
        {
            var employee = await _context.Employees
                .Include(e => e.EmployeePasscode)
                .Include(e => e.EmployeeLogs)
                .SingleOrDefaultAsync(e => e.EmployeeId == employeeId);

            if (employee is null)
            {
                return null;
            }

            var employeeResponse = _mapper.Map<Employee>(employee);

            return employee;
        }

        public async Task<List<Employee>> GetEmployeesOfSuperMarket(Guid superMarketId)
        {
            var employees = await _context.Employees
                .Where(e => e.SupermarketId == superMarketId)
                .ToListAsync();

            if (employees is null)
            {
                return null;
            }

            var employeeResponse = _mapper.Map<List<Employee>>(employees);

            return employeeResponse;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return _mapper.Map<List<Employee>>(await _context.Employees.ToListAsync());
        }

        public async Task<Employee?> UpdateEmployee(Guid employeeId, EmployeeRequestDto employeeRequest, int passcode)
        {
            var employeeToUpdate = await _context.Employees
                .Include(e => e.EmployeePasscode)
                .SingleOrDefaultAsync(e => e.EmployeeId == employeeId);

            if (employeeToUpdate is null)
            {
                return null;
            }

            UpdateEmployeeDetails(employeeToUpdate, employeeRequest, passcode);

            await _context.SaveChangesAsync();

            var employeeResponse = _mapper.Map<Employee>(employeeToUpdate);

            return employeeResponse;

        }

        private void UpdateEmployeeDetails(Employee employee, EmployeeRequestDto employeeRequest, int passcode)
        {
            employee.Address = employeeRequest.Address;
            employee.PhoneNumber = employeeRequest.PhoneNumber;
            employee.EmployeeName = employeeRequest.EmployeeName;
            employee.EmployeePasscode.Passcode = passcode;
            employee.EmployeeImage = employeeRequest.EmployeeImage;
        }
    }
}
