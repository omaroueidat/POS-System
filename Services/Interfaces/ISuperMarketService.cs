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
        public Task<List<SuperMarketResponseDto>> GetSuperMarkets();
        public Task<SuperMarketResponseDto?> GetSuperMarket(Guid supermarketId);
        
        // Method for Login Authentication
        public Task<SuperMarket?> GetSuperMarketByAppUserId(Guid appUserId);
        public Task<SuperMarketResponseDto> CreateNewSupermarket(SuperMarketRequestDto supermarket);
        public Task<bool> DeleteSupermarket(Guid supermarketId);
        public Task<bool> UpdateSupermarket(SuperMarketRequestDto supermarket, Guid supermarketId, string email, string password);
    }
}
