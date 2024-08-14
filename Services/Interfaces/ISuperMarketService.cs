using Entities.DTO.Request;
using Entities.DTO.Response;
using Entities.Models.SuperMarketModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ISuperMarketService
    {
        public Task<SuperMarketResponseDto> Authenticate(string email, string password);
        public Task<List<SuperMarketResponseDto>> GetSuperMarkets();
        public Task<SuperMarketResponseDto?> GetSuperMarket(Guid supermarketId);
        public Task<SuperMarketResponseDto> CreateNewSupermarket(SuperMarketRequestDto supermarket);
        public Task<bool> DeleteSupermarket(Guid supermarketId);
        public Task<bool> UpdateSupermarket(SuperMarketRequestDto supermarket, Guid supermarketId);
    }
}
