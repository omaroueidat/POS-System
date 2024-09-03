using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Domain.Application
{
    public class AppUser : IdentityUser<Guid>
    {
        [Required]
        public string? Role { get; set; }

    }
}
