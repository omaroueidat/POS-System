using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Request
{
    public class AppUserRequest
    {
        [Required]
        public string? email { get; set; }

        [Required]
        public string? password { get; set; }

        [Required]
        public string? roles { get; set; }

        [Required]
        public string? username { get; set; }
    }
}
