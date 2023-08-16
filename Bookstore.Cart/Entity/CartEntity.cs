using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Cart.Entity
{
    public class CartEntity
    {
        [Key]
        public string CartId { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public int UserId { get; set; }
        
        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [NotMapped]
        public UserEntity User { get; set; }
        [NotMapped]
        public BookEntity Book { get; set; }

    }
}
