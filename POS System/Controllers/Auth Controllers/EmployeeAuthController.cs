using AutoMapper;
using Entities.DTO.Request;
using Entities.DTO.Response;
using Entities.Models.EmployeeModels;
using Entities.Models.SuperMarketModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS_System.CustomActionFilters;
using Services.Interfaces;

namespace POS_System.Controllers.Auth_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAuthController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public EmployeeAuthController(IEmployeeService employeeService, ITokenService tokenService, IMapper mapper)
        {
            _employeeService = employeeService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        // POST: api/Auth/Login
        [HttpPost]
        [Route("Login")]
        [ValidateModel]
        public async Task<IActionResult> Login([FromBody] EmployeeLoginRequest employeeLoginRequest)
        {
            var employeeResponse = await _employeeService.Authenticate(employeeLoginRequest.passcode);

            if (employeeResponse is null)
            {
                return BadRequest("Wrong Passcode! Try Agian");
            }

            // Map the EmployeeLoginRequest to Employee to use it in the CreateJwtTokenMethod
            var employee = _mapper.Map<Employee>(employeeResponse);

            // Create Token
            var jwtToken = _tokenService.CreateJwtTokenForEmployee(employee);

            var response = new SuperMarketLoginResponseDto()
            {
                JwtToken = jwtToken
            };

            return Ok(response);
        }
    }
}
