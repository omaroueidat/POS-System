using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Request
{
    public class CustomerRequestDto
    {
        [MaxLength(30)]
        [Required]
        public string? CustomerName { get; set; }

        public int PhoneNumber { get; set; }

        [MaxLength(30)]
        [Required]
        public string? CustomerAddress { get; set; }
    }
}
