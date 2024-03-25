using System.ComponentModel.DataAnnotations;
namespace OnlineGroceryStore.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
