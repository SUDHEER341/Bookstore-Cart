using Bookstore.Cart.Entity;

namespace Bookstore.Cart.Interface
{
    public interface ICartServices
    {
        Task<CartEntity> AddToCart(string token, int userId, int bookId, int quantity );
        IEnumerable<CartEntity> GetMyCart(int userId);

        bool DeleteCartItemByQuantity(int id);

    }
}
