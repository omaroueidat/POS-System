using Entities.DTO.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using POS_System.CustomActionFilters;
using Services.Interfaces;

namespace POS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperMarketController : ControllerBase
    {
        private readonly ISuperMarketService _superMarketService;

        public SuperMarketController(ISuperMarketService superMarketService)
        {
            _superMarketService = superMarketService;
        }

        [HttpGet]
        [Authorize] // the user should be logged in as a supermarket to access this method
        public async Task<IActionResult> GetAllSuperMarkets()
        {

            var superMarkets = await _superMarketService.GetSuperMarkets();

            return Ok(superMarkets);
        }

        [HttpGet("{superMarketId:guid}")]
        [Authorize]
        public async Task<IActionResult> GetSuperMarket(Guid superMarketId)
        {
            var superMarket = await _superMarketService.GetSuperMarket(superMarketId);

            if (superMarket is null)
            {
                return NotFound();
            }

            return Ok(superMarket);
        }

        [HttpPost]
        [ValidateModel] // for model attribute validations
        [Authorize]
        public async Task<IActionResult> AddNewSuperMarket(SuperMarketRequestDto superMarketRequest)
        {
            var superMarket = await _superMarketService.CreateNewSupermarket(superMarketRequest);

            if (superMarket is null)
            {
                return BadRequest("An unexpected error happened! Try Again");
            }

            return CreatedAtAction(nameof(GetSuperMarket), new { id = superMarket.Id }, superMarket);
        }

        [HttpPut("{superMarketId:guid}")]
        [ValidateModel]
        [Authorize]
        public async Task<IActionResult> UpdateSuperMarket(SuperMarketRequestDto superMarketRequest, Guid superMarketId)
        {
            bool isUpdated = await _superMarketService.UpdateSupermarket(superMarketRequest, superMarketId);

            if (!isUpdated)
            {
                return ValidationProblem("Error: Unexpected Error Occured! Please try agian Later");
            }

            return Ok();
        }

        [HttpDelete("{superMarketId:guid}")]
        [Authorize]
        public async Task<IActionResult> DeleteSuperMarket(Guid superMarketId)
        {
            bool isDeleted = await _superMarketService.DeleteSupermarket(superMarketId);

            if (!isDeleted)
            {
                return NotFound($"The SuperMarket with ID {superMarketId} was not found!");
            }

            return Ok();
        }
    }
}
