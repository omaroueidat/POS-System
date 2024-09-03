using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Register
{
    public class EmployeeRegisterDto
    {

        // Employee Creation Attributes

        [MaxLength(30)]
        [Required]
        public string? EmployeeName { get; set; }

        [MaxLength(40)]
        [Required]
        public string? Address { get; set; }

        public int PhoneNumber { get; set; }

        // App User Register

        [Required]
        [EmailAddress]
        public string? email { get; set; }

        [Required]
        public string? password { get; set; }

        [Required]
        [AllowedValues("Employee", ErrorMessage = "Allowed Values are: Employee")] // This will specify the allowed values for roles
        public string? roles { get; set; }
    }
}
