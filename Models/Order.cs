using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineGroceryStore.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        [ForeignKey("UserId")]
        public  User User { get; set; }
    }
}
