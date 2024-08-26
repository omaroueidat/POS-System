using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.SuperMarketModels
{
    /// <summary>
    /// This is a model for logging imports and exports of any product to the stock
    /// </summary>
    public class StockLog
    {
        [Key]
        public Guid StockLogId { get; set; }

        public Guid StockId { get; set; }
        public DateTime HistoryDate { get; set; }

        [Required]
        [MaxLength(6)]
        public string? Operation { get; set; }


        // For Navigation
        [ForeignKey("StockId")]
        public virtual Stock? Stock { get; set; }
    }
}
