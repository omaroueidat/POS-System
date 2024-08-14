using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.ProductModels;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.InvoiceModels
{
    public class InvoiceDetails
    {
        [Key]
        public Guid InvoiceDetailsId { get; set; }
        public Guid InvoiceId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        // For Navigation
        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }
    }
}
