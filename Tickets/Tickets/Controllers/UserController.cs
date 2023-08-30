using Microsoft.AspNetCore.Mvc;
using Ticket.Models;
using Tickets.Models;
using Tickets.ViewModels;

namespace Ticket.Controllers
{
    public class UserController : Controller
    {
        myDbContext dbContext;
        public UserController(myDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// ///////////////////////////////////
        [HttpGet]
        public IActionResult Order()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Order(Order order)
        {
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();
            //if (!ModelState.IsValid) 
            //{ 
            //    return View(actor); 
            //}
            //-service.Add(actor);

            return RedirectToAction("Index");

        }

        /// </summary>
        /// <returns></returns>

        public IActionResult profile()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if(userId == null)
            {
                return RedirectToAction("Login");
            }
            User currentUser = dbContext.Users.FirstOrDefault(u => u.Id ==userId);
            return View(currentUser);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            if(user == null)
            {
                return View("myError");
            }
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            return RedirectToAction("Login");
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            LoginVM loginvm = new LoginVM();
            return View(loginvm);
        }

        [HttpPost]
        public IActionResult Login(LoginVM login)
        {
            User user = dbContext.Users.SingleOrDefault(u => u.Email == login.Email && u.Password == login.Password);
            if(user == null)
            {
                LoginVM loginvm = new LoginVM();
                loginvm.Message = "Wrong Email or Password";
                return View("Login",loginvm);
            }
            HttpContext.Session.SetInt32("UserId", user.Id);
            return RedirectToAction("Profile");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
