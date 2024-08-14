using Entities.Models.InvoiceModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.SuperMarketModels
{
    public class SalesHistory
    {
        [Key]
        public Guid SalesHistoryId { get; set; }

        public Guid InvoiceId { get; set; }
        public float Profit { get; set; }

        // For Navigation
        [ForeignKey("InvoiceId")]
        public virtual Invoice? Invoice { get; set; }
    }
}
