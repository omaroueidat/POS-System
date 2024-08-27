using AutoMapper;
using Entities.DTO.Request;
using Entities.DTO.Response;
using Entities.Models.SuperMarketModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using POS_System.CustomActionFilters;
using Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;

namespace POS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperMarketAuthController : ControllerBase
    {
        private readonly ISuperMarketService _superMarketService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public SuperMarketAuthController(ISuperMarketService superMarketService, ITokenService tokenService, IMapper mapper)
        {
            _superMarketService = superMarketService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        // POST: api/Auth/Register
        [HttpPost]
        [Route("Register")]
        [ValidateModel]
        public async Task<IActionResult> Register([FromBody] SuperMarketRequestDto superMarketRequest)
        {
            var superMarket = await _superMarketService.CreateNewSupermarket(superMarketRequest);

            return CreatedAtAction(nameof(SuperMarketController.GetSuperMarket), new { superMarketId = superMarket.Id });
        }

        // POST: api/Auth/Login
        [HttpPost]
        [Route("Login")]
        [ValidateModel]
        public async Task<IActionResult> Login([FromBody] SuperMarketLoginRequest superMarketRequest)
        {
            var superMarketResponse = await _superMarketService.Authenticate(superMarketRequest.Email, superMarketRequest.Password);


            if (superMarketResponse is null)
            {
                return BadRequest("Email or Password is incorrect");
            }

            // Map the SuperMarketResposnse to SuperMarket
            var superMarket = _mapper.Map<SuperMarket>(superMarketResponse);

            // Create Token
            var jwtToken = _tokenService.CreateJwtToken(superMarket);

            var response = new SuperMarketLoginResponseDto()
            {
                JwtToken = jwtToken
            };

            return Ok(response);
        }

    }
}
