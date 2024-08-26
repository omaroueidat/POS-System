using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Domain.Product
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }


        public string? CategoryName { get; set; }

        public string? CategoryImage { get; set; }
    }
}
