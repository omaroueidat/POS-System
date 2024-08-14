using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.EmployeeModels
{
    public class EmployeeLog
    {
        [Key]
        public Guid EmployeeLogId { get; set; }

        public Guid EmployeeId { get; set; }

        public DateTime LogInDate { get; set; }
        public DateTime LogOutDate { get; set; }
    }
}
