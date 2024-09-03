using Entities.Domain.Application;
using Entities.DTO.Request;
using Entities.Models.EmployeeModels;
using Entities.Models.SuperMarketModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITokenService
    {
        public string CreateJwtTokenForEmployee(AppUser user, Employee employee, string role);
        public string CreateJwtTokenForSuperMarket(AppUser user, SuperMarket superMarket, string role);
        public string CreateJwtTokenForAdmin(AppUser user, Admin admin, string role);
    }
}