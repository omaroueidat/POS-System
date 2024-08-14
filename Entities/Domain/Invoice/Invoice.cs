using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.EmployeeModels;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.InvoiceModels
{
    public class Invoice
    {
        [Key]
        public Guid InvoiceId { get; set; }

        public Guid EmployeeId { get; set; }
        public float Total { get; set; }

        // For Navigation
        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; }

        public virtual List<InvoiceDetails>? InvoiceDetails { get; set; }
    }
}
