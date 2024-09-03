using Entities.Models.SuperMarketModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Request
{
    public class SuperMarketRequestDto
    {
        [MaxLength(30)]
        [Required]
        public string? SupermarketName { get; set; }

        [MaxLength(30)]
        [Required]
        public string? Address { get; set; }

        public int PhoneNumber { get; set; }
    }
}
