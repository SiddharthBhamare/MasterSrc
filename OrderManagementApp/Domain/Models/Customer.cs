using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Customer")]
    public class Customer
    {

        [Key]
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Bill> Bills { get; set; }

    }
}
