using Bookstore.Cart.Context;
using Bookstore.Cart.Entity;
using Bookstore.Cart.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Bookstore.Cart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartServices _cart;
        public ResponseEntity response;

        public CartController(ICartServices cart)
        {
            _cart = cart;
            response = new ResponseEntity();
        }


        [Authorize]
        [HttpPost]
        [Route("Create")]
        public async Task<ResponseEntity> AddOrder(int bookId, int quantity)
        {
            string jwtTokenWithBearer = HttpContext.Request.Headers["Authorization"];
            string jwtToken = jwtTokenWithBearer.Substring("Bearer ".Length);

            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Sid));

            CartEntity newOrder = await _cart.AddToCart(jwtToken, userId, bookId, quantity);
            if (newOrder != null)
            {
                response.Data = newOrder;
            }

            else
            {
                response.IsSuccess = false;
                response.Message = "something gone wrong please check again";
            }

         return response;
        }

        [Authorize]
        [HttpGet]
        [Route("GetCart")]
        public ResponseEntity GetCart()
        {
            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Sid));

            IEnumerable<CartEntity> cart = _cart.GetMyCart(userId);

            if (cart.Any())
            {
                response.Data = cart;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "something gone wrong, please check again";
            }

            return response;
        }
       
        [Authorize]
        [HttpDelete]
        [Route("DeleteCartItem")]
        public ResponseEntity DeleteCartItemByQuantity(int id)
        {
            bool result = _cart.DeleteCartItemByQuantity(id);
            if (result)
            {
                response.Data = result;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "something gone wrong";
            }
            return response;
        }
    }
}
