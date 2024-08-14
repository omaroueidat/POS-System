using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.ProductModels
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }

        public long ProductCode { get; set; }
        public float Price { get; set; }
        public float Cost { get; set; }
        public DateTime ManDate { get; set; }
        public DateTime ExpDate { get; set; }
    }
}
