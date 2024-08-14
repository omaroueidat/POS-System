using Entities.Models.EmployeeModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Request
{
    public class InvoiceRequestDto
    {
        public Guid EmployeeId { get; set; }
    }
}
