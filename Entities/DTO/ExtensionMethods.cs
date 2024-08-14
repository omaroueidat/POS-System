using Entities.DTO.Request;
using Entities.Models.SuperMarketModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public static class ExtensionMethods
    {
        public static SuperMarket ToSuperMarket(this SuperMarketRequestDto superMarketRequest)
        {
            return new SuperMarket()
            {
                SupermarketName = superMarketRequest.SupermarketName,
                Address = superMarketRequest.Address,
                PhoneNumber = superMarketRequest.PhoneNumber,
                Email = superMarketRequest.Email,
                Password = superMarketRequest.Password
            };
        }
    }
}
