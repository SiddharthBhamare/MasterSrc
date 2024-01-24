using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Bills")]
    public class Bill
    {
        [Key]
        public int BillId { get; set; }

        public decimal TotalAmount { get; set; }

        public int OrderId { get; set; }
        public Order order { get; set; }
    }
}
