using Bookstore.Cart.Context;
using Bookstore.Cart.Entity;
using Bookstore.Cart.Interface;

namespace Bookstore.Cart.Service
{
    public class CartService : ICartServices
    {
        private readonly CartContext _db;
        private readonly IBookServices _book;
        private readonly IUserServices _user;

        public CartService(CartContext db , IBookServices book , IUserServices user)
        {
            _db = db;
            _book = book;
            _user = user;
        }
        public async Task<CartEntity> AddToCart(string token, int userId, int bookId, int quantity )
        {
            
                CartEntity newOrder = new CartEntity()
                {
                    CartId = Guid.NewGuid().ToString(),
                    BookId = bookId,
                    UserId = userId,
                    Quantity = quantity,
                   
                    Book = await _book.GetBookById(bookId),
                    
                    User = await _user.GetUser(token)

                };

                var cartItemExists =  _db.Cart.FirstOrDefault(x => x.BookId == bookId);

                if (cartItemExists != null)
                {
                    cartItemExists.Quantity++;

                }
                else
                {
                    _db.Cart.Add(newOrder);
                }
                
                _db.SaveChanges();
                return newOrder;
            //return "Item Addded to cart successfully";
            
        }
        public IEnumerable<CartEntity> GetMyCart(int userId)
        {
            IEnumerable<CartEntity> cart = _db.Cart.Where(c => c.UserId == userId);
            return cart;
        }

        //MAIN
        //public bool DeleteCartItem(int id)
        //{
        //    CartEntity book = _db.Cart.FirstOrDefault(x => x.BookId == id);
        //    if (book != null)
        //    {

        //        _db.Cart.Remove(book);
        //        _db.SaveChanges();
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //Modified
        public bool DeleteCartItemByQuantity(int id)
        {
            CartEntity book = _db.Cart.FirstOrDefault(x => x.BookId == id);
            
            if(book == null)
            {
                return false;
                
            }
            if (book.Quantity > 1)
            {
                book.Quantity = book.Quantity - 1;
                _db.SaveChanges();

                return true;
            }
            else
            {
                _db.Cart.Remove(book);
                _db.SaveChanges();

                return true;
            }

        }

    }
}

