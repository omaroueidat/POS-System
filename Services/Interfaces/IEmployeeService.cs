using Entities.DTO.Request;
using Entities.Models.EmployeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IEmployeeService
    {
        public Task<Employee> GetEmployee(Guid employeeId);

        public Task<List<Employee>> GetEmployees();

        public Task<List<Employee>> GetEmployeesOfSuperMarket(Guid superMarketId);

        public Task<Employee> AddNewEmployee(EmployeeRequestDto employeeRequest);

        public Task<Employee?> UpdateEmployee(Guid employeeId, EmployeeRequestDto employeeRequest, int passcode);

        public Task<bool> DeleteEmployee(Guid employeeId);
    }
}
