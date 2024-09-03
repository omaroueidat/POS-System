using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Domain.Application
{
    public class Admin
    {
        [Key]
        public Guid AdminId { get; set; }

        public Guid AppUserId { get; set; }

        // For Navigation
        [ForeignKey("AppUserId")]
        public virtual AppUser? AppUser { get; set; }
    }
}
