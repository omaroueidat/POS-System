using Entities.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.SuperMarketModels
{
    public class Stock
    {
        [Key]
        public Guid StockId { get; set; }
        public Guid ProductId { get; set; }
        public Guid SuperMarketId { get; set; }
        public long Quantity { get; set; }

        // For Navigation
        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }
    }
}
