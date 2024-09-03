using AutoMapper;
using Entities.Domain.Application;
using Entities.DTO.Login;
using Entities.DTO.Register;
using Entities.DTO.Request;
using Entities.Models.EmployeeModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using POS_System.CustomActionFilters;
using Services.Interfaces;

namespace POS_System.Controllers.Auth_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> usermanager;
        private readonly IEmployeeService _employeeService;

        public EmployeeAuthController(ITokenService tokenService, IMapper mapper, UserManager<AppUser> usermanager, IEmployeeService employeeService)
        {
            _tokenService = tokenService;
            _mapper = mapper;
            this.usermanager = usermanager;
            _employeeService = employeeService;
        }

        [Authorize(Roles = "SuperMarket")]
        [HttpPost("[action]")]
        [ValidateModel]
        public async Task<IActionResult> Register(EmployeeRegisterDto employeeeRegister, IFormFile image)
        {
            var identityUser = new AppUser()
            {
                Email = employeeeRegister.email
            };

            var identityResult = await usermanager.CreateAsync(identityUser, employeeeRegister.password);

            if (identityResult.Succeeded)
            {
                // Add Roles to this user
                if (employeeeRegister.roles == "Employee")
                {
                    identityResult = await usermanager.AddToRoleAsync(identityUser, employeeeRegister.roles);

                    if (identityResult.Succeeded)
                    {
                        // If the AppUser Registration was successfull then we have to add the Employee to EmployeeTable
                        var employeeRequest = _mapper.Map<EmployeeRequestDto>(employeeeRegister);

                        await _employeeService.AddNewEmployee(employeeRequest, image);

                        return Ok("Employee was registered!");
                    }
                }
            }

            return BadRequest("A Problem Occured! Check your request and try again!");
        }

        [ValidateModel]
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(AppUserLogin userRequest)
        {
            var user = await usermanager.FindByEmailAsync(userRequest.email);

            // Verify Password

            if (user is null)
            {
                return NotFound("We couldn't find what your looking for! Try Agian Later");
            }

            var employee = await _employeeService.GetEmployeeByAppUserId(user.Id);

            if (employee is null)
            {
                return NotFound("We couldn't find what your looking for! Try Agian Later");
            }

            // Return JWT Token
            var token = _tokenService.CreateJwtTokenForEmployee(user, employee, "Employee");

            var response = new EmployeeLoginResponseDto()
            {
                JwtToken = token
            };

            return Ok(response);
        }
    }
}
