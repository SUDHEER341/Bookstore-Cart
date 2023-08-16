using Bookstore.Cart.Entity;

namespace Bookstore.Cart.Interface
{
    public interface IBookServices
    {
        Task<BookEntity> GetBookById(int id);

    }
}
