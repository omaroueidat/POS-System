using Entities.Models.EmployeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Response
{
    public class SuperMarketResponseDto
    {
        public Guid Id { get; set; }
        public string? SupermarketName { get; set; }
        public string? Address { get; set; }

        public int PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }
        public List<Models.EmployeeModels.Employee>? Employees { get; set; }
    }
}
