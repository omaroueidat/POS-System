using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Entities.Models.InvoiceModels;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models.CustomerModels
{
    [PrimaryKey("CustomerId", "InvoiceId")]
    public class CustomerInvoice
    {
        public Guid CustomerId { get; set; }

        public Guid InvoiceId { get; set; }

        // For Navigation
        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }

        [ForeignKey("InvoiceId")]
        public virtual Invoice? Invoice { get; set; }
    }
}
