using Entities.DTO.Request;
using Entities.DTO.Response;
using Entities.Models.EmployeeModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IEmployeeService
    {
        public Task<EmployeeResponseDto> GetEmployee(Guid employeeId);

        public Task<List<EmployeeResponseDto>> GetEmployees();

        public Task<List<EmployeeResponseDto>> GetEmployeesOfSuperMarket(Guid superMarketId);

        // Method for Employee Authentication
        public Task<Employee> GetEmployeeByAppUserId(Guid AppUserId);

        public Task<EmployeeResponseDto?> AddNewEmployee(EmployeeRequestDto employeeRequest, IFormFile image, Guid superMarketId);

        public Task<EmployeeResponseDto?> UpdateEmployee(Guid employeeId, EmployeeRequestDto employeeRequest, IFormFile image, string email, string password);

        public Task<bool> DeleteEmployee(Guid employeeId);

    }
}
