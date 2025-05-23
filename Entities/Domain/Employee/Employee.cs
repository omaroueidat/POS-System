﻿using Entities.Domain.Application;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.EmployeeModels
{
    public class Employee
    {
        [Key]
        public Guid EmployeeId { get; set; }
        public Guid AppUserId { get; set; }

        public Guid SupermarketId { get; set; }

        [MaxLength(30)]
        public string? EmployeeName { get; set; }

        public string? EmployeeImage { get; set; }

        [MaxLength(40)]
        public string? Address { get; set; }

        public int PhoneNumber { get; set; }
        
        // For Navigation 
        public virtual List<EmployeeLog>? EmployeeLogs { get; set; }

        [ForeignKey("AppUserId")]
        public virtual AppUser? AppUser { get; set; }
    }
}
