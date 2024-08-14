using Entities.Models.EmployeeModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.SuperMarketModels
{
    public class SuperMarket : IdentityUser<Guid>
    {
        public string? SupermarketName { get; set; }
        public string? Address { get; set; }

        public int PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        // For Navigation
        public virtual List<Employee>? Employees { get; set; }
    }
}
