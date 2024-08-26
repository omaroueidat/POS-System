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
        string CreateJwtToken(SuperMarket superMakret);

        string CreateJwtTokenForEmployee(Employee employee);
    }
}
