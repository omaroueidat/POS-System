using AutoMapper;
using Entities.Domain.Application;
using Entities.DTO.Login;
using Entities.DTO.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using POS_System.CustomActionFilters;
using Services.Interfaces;
using System.Security.Claims;

namespace POS_System.Controllers.Auth_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminAuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> usermanager;
        private readonly IAdminService _adminService;

        public AdminAuthController (ITokenService tokenService, IMapper mapper, UserManager<AppUser> usermanager, IAdminService adminService)
        {
            _tokenService = tokenService;
            _mapper = mapper;
            this.usermanager = usermanager;
            _adminService = adminService;
        }

        [ValidateModel]
        [HttpPost("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Register(AppUserRequest userRequest)
        {

            var identityUser = new AppUser()
            {
                Id = Guid.NewGuid(),
                Email = userRequest.email,
                UserName = userRequest.username,
                NormalizedEmail = userRequest.email.ToUpper(),
                NormalizedUserName = userRequest.username.ToUpper(),
                Role = userRequest.roles
            };

            var identityResult = await usermanager.CreateAsync(identityUser, userRequest.password);

            if (identityResult.Succeeded)
            {
                // Add Roles to this user
                if (userRequest.roles == "Admin")
                {
                    identityResult = await usermanager.AddToRoleAsync(identityUser, userRequest.roles);

                    if (identityResult.Succeeded)
                    {
                        // If the AppUser Registration was successfull then we have to add Admin to Admin Table
                        Admin admin = new Admin()
                        {
                            AdminId = Guid.NewGuid(),
                            AppUserId = identityUser.Id,
                        };

                        await _adminService.AddNewAdmin(admin);

                        return Ok("User was registered! Please Login!");
                    }
                }
            }

            return BadRequest("A Problem Occured! Check your request and try again!");
        }

        [ValidateModel]
        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AppUserLogin userRequest)
        {
            var user = await usermanager.FindByEmailAsync(userRequest.email);

            if (user is null)
            {
                return NotFound("We couldn't find what your looking for! Try Agian Later");
            }

            var admin = await _adminService.GetAdmin(user.Id);

            if (admin is null)
            {
                return NotFound("We couldn't find what your looking for! Try Agian Later");
            }

            // Return JWT Token
            var token = _tokenService.CreateJwtTokenForAdmin(user, admin, "Admin");

            var response = new AdminLoginResponseDto()
            {
                JwtToken = token
            };

            return Ok(response);
        }
    }
}
