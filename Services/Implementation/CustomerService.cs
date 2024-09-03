using AutoMapper;
using Entities.Database_Context;
using Entities.DTO.Request;
using Entities.DTO.Response;
using Entities.Models.CustomerModels;
using Entities.Models.SuperMarketModels;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CustomerService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomerResponseDto> AddNewCustomer(CustomerRequestDto customerRequest)
        {
            var customer = _mapper.Map<Customer>(customerRequest);

            await _context.Customers.AddAsync(customer);

            await _context.SaveChangesAsync();

            return _mapper.Map<CustomerResponseDto>(customer);
        }

        public async Task<bool> DeleteCustomer(Guid customerId, Guid superMarketId)
        {
            // Joining to check if the customer belongs to the supermarket that is trying to delete
            var customer = await _context.Customers
                .Where(c => c.CustomerId == customerId)
                .Join(_context.CustomerInvoices,
                      c => c.CustomerId,
                      ci => ci.CustomerId,
                      (c, ci) => new { Customer = c, ci.InvoiceId })
                .Join(_context.Invoices,
                      ci => ci.InvoiceId,
                      i => i.InvoiceId,
                      (ci, i) => new { ci.Customer, i.EmployeeId })
                .Join(_context.Employees,
                      i => i.EmployeeId,
                      e => e.EmployeeId,
                      (i, e) => new { i.Customer, e.SupermarketId })
                .FirstOrDefaultAsync(e => e.SupermarketId == superMarketId);

            if (customer is null)
            {
                return false;
            }

            _context.Customers.Remove(customer.Customer);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<CustomerResponseDto>?> GetAllCustomers(Guid superMarketId)
        {
            // Joining to get the customers of the SuperMarket.
            var customers = await _context.Customers
                .Join(_context.CustomerInvoices,
                    c => c.CustomerId,
                    ci => ci.CustomerId,
                    (c, ci) => new { Customer = c, ci.InvoiceId })
                .Join(_context.Invoices,
                    ci => ci.InvoiceId,
                    i => i.InvoiceId,
                    (ci, i) => new { ci.Customer, i.EmployeeId })
                .Join(_context.Employees,
                    ci => ci.EmployeeId,
                    e => e.EmployeeId,
                    (ci, e) => new { ci.Customer, e.SupermarketId })
                .Select(c => c.SupermarketId == superMarketId)
                .ToListAsync();

            if (customers is null)
            {
                return null;
            }

            var responseCustomers = _mapper.Map<List<CustomerResponseDto>>(customers);

            return responseCustomers;
        }

        public async Task<CustomerResponseDto?> GetCustomer(Guid customerId, Guid superMarketId)
        {
            // Same as delete, have to check if the customer bleongs to the superMarket before giving his details
            var customer = await _context.Customers
                .Where(c => c.CustomerId == customerId)
                .Join(_context.CustomerInvoices,
                    c => c.CustomerId,
                    ci => ci.CustomerId,
                    (c, ci) => new { Customer = c, ci.InvoiceId })
                .Join(_context.Invoices,
                    ci => ci.InvoiceId,
                    i => i.InvoiceId,
                    (ci, i) => new { ci.Customer, i.EmployeeId })
                .Join(_context.Employees,
                    ci => ci.EmployeeId,
                    e => e.EmployeeId,
                    (ci, e) => new { ci.Customer, e.SupermarketId })
                .SingleOrDefaultAsync(c => c.SupermarketId == superMarketId);


            if (customer is null)
            {
                return null;
            } 

            var customerResponse = _mapper.Map<CustomerResponseDto>(customer);

            return customerResponse;
        }

        public async Task<CustomerResponseDto?> UpdateCustomer(Guid customerId, Guid superMarketId, CustomerRequestDto customerRequest)
        {
            // check is the customer exist and belong to the supermaket that is trying to update the customer
            var customer = await _context.Customers
                .Where(c => c.CustomerId == customerId)
                .Join(_context.CustomerInvoices,
                    c => c.CustomerId,
                    ci => ci.CustomerId,
                    (c, ci) => new { Customer = c, ci.InvoiceId })
                .Join(_context.Invoices,
                    ci => ci.InvoiceId,
                    i => i.InvoiceId,
                    (ci, i) => new { ci.Customer, i.EmployeeId })
                .Join(_context.Employees,
                    ci => ci.EmployeeId,
                    e => e.EmployeeId,
                    (ci, e) => new { ci.Customer, e.SupermarketId })
                .SingleOrDefaultAsync(c => c.SupermarketId == superMarketId);

            if (customer is null)
            {
                return null;
            }

            var customerToUpdate = await _context.Customers
                .SingleOrDefaultAsync(c => c.CustomerId == customerId);

            UpdateCustomerDetails(customerToUpdate, customerRequest);

            await _context.SaveChangesAsync();

            return _mapper.Map<CustomerResponseDto>(customerToUpdate);

        }

        private void UpdateCustomerDetails(Customer customer, CustomerRequestDto customerRequest)
        {
            customer.CustomerAddress = customerRequest.CustomerAddress;
            customer.PhoneNumber = customerRequest.PhoneNumber;
            customer.CustomerName = customerRequest.CustomerName;
        }
    }
}
