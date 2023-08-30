using Microsoft.AspNetCore.Mvc;

namespace Tickets.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult AddToCart(int id)
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
