using ECommerce.Helpers;
using Entities;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTOs;

namespace ECommerce.Controllers
{
    [Route("[controller]")]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        const string CART_KEY = "MYCART";
        public List<CartDTO> _carts => HttpContext.Session.Get<List<CartDTO>>(CART_KEY) ?? new List<CartDTO>();
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
            //_carts = HttpContext.Session.Get<List<CartDTO>>(CART_KEY) ?? new List<CartDTO>();
        }

        [HttpGet("[action]")]
        public IActionResult Index()
        {
            return View(_carts); 
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddToCart(int id, int quantity = 1)
        {
            List<CartDTO> cartItems = _carts;
            CartDTO cart = await _cartService.AddItemToCart(id, quantity, cartItems);
            HttpContext.Session.Set(CART_KEY, cartItems);
            return RedirectToAction("Index");
        }
        [HttpPost("[action]")]
        public IActionResult RemoveFromCart(int id)
        {
            List<CartDTO> cartItems = _carts;
            bool temp = _cartService.RemoveFromCart(id, cartItems);
            if (temp)
            {
                HttpContext.Session.Set(CART_KEY, cartItems);
            }
            return RedirectToAction("Index");
        }
    }
}
