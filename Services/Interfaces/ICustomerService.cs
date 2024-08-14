using Entities.DTO.Request;
using Entities.DTO.Response;
using Entities.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICustomerService
    {
        public Task<CustomerResponseDto> AddNewCustomer(CustomerRequestDto customerRequest);
        public Task<List<CustomerResponseDto>?> GetAllCustomers(Guid superMarketId);
        public Task<CustomerResponseDto?> GetCustomer(Guid customerId, Guid superMarketId);
        public Task<CustomerResponseDto?> UpdateCustomer(Guid customerId, Guid superMarketId, CustomerRequestDto customerRequest);
        public Task<bool> DeleteCustomer(Guid customerId, Guid superMarketId);
    }
}
