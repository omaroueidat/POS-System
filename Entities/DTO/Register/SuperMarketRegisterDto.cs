using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Register
{
    public class SuperMarketRegisterDto
    {
        // Attributes for SuperMarketRegister

        [MaxLength(30)]
        [Required]
        public string? SupermarketName { get; set; }

        [MaxLength(30)]
        [Required]
        public string? Address { get; set; }

        public int PhoneNumber { get; set; }

        // Attributes for AppUser

        [Required]
        [EmailAddress]
        public string? email { get; set; }

        [Required]
        public string? password { get; set; }

        [Required]
        [AllowedValues("SuperMarket", ErrorMessage = "Allowed Values are: SuperMarket")] // This will specify the allowed values for roles
        public string? roles { get; set; }
    }
}
