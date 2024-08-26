using Entities.Domain.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.ProductModels
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }
        public long ProductCode { get; set; }
        public float Price { get; set; }
        public float Cost { get; set; }

        // Adding Discount
        public decimal Discount { get; set; }

        // Adding Description to product
        public string? Description { get; set; }

        // Adding Image to poduct
        public string? ProductImage { get; set; }

        public DateTime ManDate { get; set; }
        public DateTime ExpDate { get; set; }

        // For Navigation
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
    }
}
