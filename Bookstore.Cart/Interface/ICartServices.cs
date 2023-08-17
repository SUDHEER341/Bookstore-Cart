using Bookstore.Cart.Entity;

namespace Bookstore.Cart.Interface
{
    public interface ICartServices
    {
        public  Task<CartEntity> AddToCart(string token, int userId, int bookId, int quantity );
        IEnumerable<CartEntity> GetMyCart();

        bool DeleteCartItem(int id);  



    }
}
