using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ticket.Models;
using Tickets.Models;
using static Ticket.Models.myDbContext;

namespace Ticket.Controllers
{
    public class MovieController : Controller
    {
        myDbContext dbcontext = new myDbContext();

        public IActionResult Index()
        {
            List<Movie> movie = dbcontext.Movies.Include(n => n.Cinema ).OrderBy(n =>n.Name).ToList();
            return View(movie);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            dbcontext.Movies.Add(movie);
            dbcontext.SaveChanges();
            //if (!ModelState.IsValid) 
            //{ 
            //    return View(actor); 
            //}
            //-service.Add(actor);

            return RedirectToAction("Index");

        }
        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>
        public IActionResult Order()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Order(Order order)
        {
            dbcontext.Orders.Add(order);
            dbcontext.SaveChanges();
            //if (!ModelState.IsValid) 
            //{ 
            //    return View(actor); 
            //}
            //-service.Add(actor);

            return RedirectToAction("Index");

        }


        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Details(int id)
        {
            Movie movie = dbcontext.Movies.SingleOrDefault(s => s.Id == id);
            return View(movie);
        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");

            }
            Movie movie = dbcontext.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return View("Done");
            }

            return View(movie);
        }
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            Movie OldMovie = dbcontext.Movies.SingleOrDefault(c => c.Id == movie.Id);


            OldMovie.Name = movie.Name;
            OldMovie.Description = movie.Description;
            OldMovie.Price = movie.Price;

            OldMovie.ImageURL = movie.ImageURL;
            OldMovie.StartDate = movie.StartDate;
            OldMovie.EndDate = movie.EndDate;
            OldMovie.MovieCategory = movie.MovieCategory;
            OldMovie.CinemaId = movie.CinemaId;
            OldMovie.ProducerId = movie.ProducerId;
            OldMovie.Producer = movie.Producer;





            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
