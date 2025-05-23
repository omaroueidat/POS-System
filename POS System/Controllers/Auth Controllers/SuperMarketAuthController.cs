﻿using AutoMapper;
using Entities.Domain.Application;
using Entities.DTO.Login;
using Entities.DTO.Register;
using Entities.DTO.Request;
using Entities.Models.SuperMarketModels;
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
    public class SuperMarketAuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> usermanager;
        private readonly ISuperMarketService _superMarketService;

        public SuperMarketAuthController(ITokenService tokenService, IMapper mapper, UserManager<AppUser> usermanager, ISuperMarketService superMarketService)
        {
            _tokenService = tokenService;
            _mapper = mapper;
            this.usermanager = usermanager;
            _superMarketService = superMarketService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("[action]")]
        [ValidateModel]
        public async Task<IActionResult> Register(SuperMarketRegisterDto superMarketRequest)
        {
            var identityUser = new AppUser()
            {
                Email = superMarketRequest.email,
                NormalizedEmail = superMarketRequest.email.ToUpper()
            };

            var identityResult = await usermanager.CreateAsync(identityUser, superMarketRequest.password);

            if (identityResult.Succeeded)
            {
                // Add Roles to this user
                if (superMarketRequest.roles == "SuperMarket")
                {
                    identityResult = await usermanager.AddToRoleAsync(identityUser, superMarketRequest.roles);

                    if (identityResult.Succeeded)
                    {
                        // If the AppUser Registration was successfull then we have to add the SuperMarket to SuperMarket Table

                        var superMarketAddRequest = _mapper.Map<SuperMarketRequestDto>(superMarketRequest);

                        await _superMarketService.CreateNewSupermarket(superMarketAddRequest);

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

            var superMarket = await _superMarketService.GetSuperMarketByAppUserId(user.Id);

            if (superMarket is null)
            {
                return NotFound("We couldn't find what your looking for! Try Agian Later");
            }

            // Return JWT Token
            var token = _tokenService.CreateJwtTokenForSuperMarket(user, superMarket, "SuperMarket");

            var response = new SuperMarketLoginResponseDto()
            {
                JwtToken = token
            };

            return Ok(response);
        }
    }
}
