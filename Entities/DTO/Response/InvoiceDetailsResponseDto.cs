using Entities.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Response
{
    public class InvoiceDetailsResponseDto
    {
        public Guid InvoiceDetailsId { get; set; }
        public Guid InvoiceId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public Product? Product { get; set; }
    }
}
