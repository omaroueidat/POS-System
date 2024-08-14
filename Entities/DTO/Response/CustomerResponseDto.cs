using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Response
{
    public class CustomerResponseDto
    {
        public Guid CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int PhoneNumber { get; set; }
        public string? CustomerAddress { get; set; }
    }
}
