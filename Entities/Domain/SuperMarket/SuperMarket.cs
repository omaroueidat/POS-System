using Entities.Domain.Application;
using Entities.Models.EmployeeModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.SuperMarketModels
{
    public class SuperMarket
    {
        public Guid SuperMarketId { get; set; }

        // FK to the corresponding AppUserId that contains definitions as email,password...
        public Guid AppUserId { get; set; }
        public string? SupermarketName { get; set; }
        public string? Address { get; set; }

        public int PhoneNumber { get; set; }

        // For Navigation
        public virtual List<Employee>? Employees { get; set; }

        [ForeignKey("AppUserId")]
        public virtual AppUser? AppUser { get; set; }
    }
}
