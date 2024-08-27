using Entities.DTO.Request;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS_System.CustomActionFilters;
using Services.Interfaces;
using System.Security.Claims;

namespace POS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // Changing the Endpoint to take the Id from the jwt token instead of passing it through the url
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetEmployeesOfSupermarket()
        { 
            // Get the Id of the logged in SuperMarket
            var authorizedSuperMarketId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // Convert the Id from string to Guid
            if (!Guid.TryParse(authorizedSuperMarketId, out var superMarketId))
            {
                return Unauthorized();
            }

            var employees = await _employeeService.GetEmployeesOfSuperMarket(superMarketId);

            if (employees is null)
            {
                return NotFound("The SuperMakret You are looking for does not exit!");
            }

            return Ok(employees);
        }

        [HttpPost]
        [ValidateModel]
        [Authorize]
        public async Task<IActionResult> CreateNewEmployee(EmployeeRequestDto employeeRequest, IFormFile image)
        {
            var imageExtension = Path.GetExtension(image.FileName);

            if (!imageExtension.Contains("jpeg") || !imageExtension.Contains("jpg"))
            {
                return Problem("The Image should have extension jpeg or jpg!",null,400);
            }

            var employee = await _employeeService.AddNewEmployee(employeeRequest, image);

            return CreatedAtAction(nameof(EmployeeController.GetEmployee),employee);
        }

        [HttpGet]
        [Authorize]
        [Route("[action]/{employeeId:guid}")]
        public async Task<IActionResult> GetEmployee(Guid employeeId)
        {
            var employee = await _employeeService.GetEmployee(employeeId);

            return Ok(employee);
        }

        [HttpPost("{employeeId:guid}")]
        [Authorize]
        public async Task<IActionResult> UpdateEmployee(Guid employeeId, EmployeeRequestDto employeeRequest, int passcode, IFormFile image)
        {
            var imageExtension = Path.GetExtension(image.FileName);

            if (!imageExtension.Contains("jpeg") || !imageExtension.Contains("jpg"))
            {
                return Problem("The Image should have extension jpeg or jpg!", null, 400);
            }

            await _employeeService.UpdateEmployee(employeeId, employeeRequest, passcode, image);

            return Ok();
        }

        [HttpDelete("{employeeId:guid}")]
        [Authorize]
        public async Task<IActionResult> DeleteEmployee(Guid employeeId)
        {
            bool isDeleted = await _employeeService.DeleteEmployee(employeeId);

            if (!isDeleted)
            {
                throw new Exception("SQL ERROR! Unable To Delete Employee");
            }

            return Ok();
        }

        [HttpGet]
        public IActionResult GetEmployeeImage(string imageUrl)
        {
            if (!System.IO.File.Exists(imageUrl))
            {
                return NotFound("Image You are searching for doesn't exist!");
            }
    
            var fileBytes = System.IO.File.ReadAllBytes(imageUrl);
            var contentType = "image/jpeg";

            return File(fileBytes, contentType);
        }
    }
}
