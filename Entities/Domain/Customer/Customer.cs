using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.CustomerModels
{
    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int PhoneNumber { get; set; }
        public string? CustomerAddress { get; set; }

    }
}
