using Entities.Models.EmployeeModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Response
{
    public class EmployeeResponseDto
    {
        public Guid EmployeeId { get; set; }

        public Guid SupermarketId { get; set; }
        public string? EmployeeName { get; set; }

        public string? EmployeeImage { get; set; }
        public string? Address { get; set; }

        public int PhoneNumber { get; set; }

        // For Navigation 
        public List<EmployeeLog>? EmployeeLogs { get; set; }

        public EmployeePasscode? EmployeePasscode { get; set; }
    }
}
