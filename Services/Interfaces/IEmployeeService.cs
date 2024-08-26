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
        public Task<Employee?> Authenticate(int passcode);
        public Task<EmployeeResponseDto> GetEmployee(Guid employeeId);

        public Task<List<EmployeeResponseDto>> GetEmployees();

        public Task<List<EmployeeResponseDto>> GetEmployeesOfSuperMarket(Guid superMarketId);

        public Task<EmployeeResponseDto> AddNewEmployee(EmployeeRequestDto employeeRequest, IFormFile image);

        public Task<EmployeeResponseDto?> UpdateEmployee(Guid employeeId, EmployeeRequestDto employeeRequest, int passcode, IFormFile image);

        public Task<bool> DeleteEmployee(Guid employeeId);

    }
}
