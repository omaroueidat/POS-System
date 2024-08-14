using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.EmployeeModels
{
    [PrimaryKey("EmployeeId", "Passcode")]
    public class EmployeePasscode
    {
        public Guid EmployeeId { get; set; }

        public int Passcode { get; set; }
    }
}
