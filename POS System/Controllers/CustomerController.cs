using Entities.DTO.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using POS_System.CustomActionFilters;
using POS_System.Dummy_Data;
using Services.Interfaces;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace POS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [Authorize(Roles = "SuperMarket")]
        [HttpGet]
        public async Task<IActionResult> GetAllCustomersOfSuperMarket()
        {
            // Get the Id of the SuperMarket from the jwt token
            var authoriedSuperMarketId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Convert the Id into Guid
            if (!Guid.TryParse(authoriedSuperMarketId, out var superMarketId))
            {
                return Forbid();
            }

            var customerResponses = await _customerService.GetAllCustomers(superMarketId);

            if (customerResponses is null)
            {
                return NotFound("No Customers Was Found! Make sure to check the SuperMarket Id!");
            }

            return Ok(customerResponses);
        }

        
        [HttpGet("{customerId:Guid}")]
        [Authorize(Roles = "SuperMarket")]
        public async Task<IActionResult> GetCustomer(Guid customerId)
        {
            // Get the SueprMarket id
            var authoriedSuperMarketId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Convert the Id into Guid
            if (!Guid.TryParse(authoriedSuperMarketId, out var superMarketId))
            {
                return Forbid();
            }

            var customerResponse = await _customerService.GetCustomer(customerId, superMarketId);

            if (customerResponse is null)
            {
                return NotFound("Customer was not found!");
            }

            return Ok(customerResponse);
        }

        [HttpPost]
        [ValidateModel] // for model attributes validation
        [Authorize(Roles = "SuperMarket")]
        public async Task<IActionResult> AddNewCustomer(CustomerRequestDto customerRequest)
        {
            var customerResponse = await _customerService.AddNewCustomer(customerRequest);

            return CreatedAtAction(nameof(CustomerController.GetCustomer), new { customerId = customerResponse.CustomerId });
        }

    }
}
