using Entities.Models.EmployeeModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Request
{
    public class EmployeeRequestDto
    {
        [Required]
        public Guid SupermarketId { get; set; }

        [MaxLength(30)]
        [Required]
        public string? EmployeeName { get; set; }

        [MaxLength(40)]
        [Required]
        public string? Address { get; set; }

        public int PhoneNumber { get; set; }

    }
}
