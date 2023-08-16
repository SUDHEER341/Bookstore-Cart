using Bookstore.Cart.Entity;

namespace Bookstore.Cart.Interface
{
    public interface IUserServices
    {
        Task<UserEntity> GetUser(string jwtToken);

    }
}
