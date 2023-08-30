using Microsoft.AspNetCore.Mvc;
using Ticket.Models;
using Tickets.Models;

namespace Ticket.Controllers
{
    public class CinemaController : Controller
    {
        myDbContext dbcontext = new myDbContext();

        public IActionResult Index()
        {
            List<Cinema> cinema = dbcontext.Cinemas.ToList();
            return View(cinema);
        }

        public IActionResult Details(int id)
        {
            Cinema cinema = dbcontext.Cinemas.SingleOrDefault(s => s.Id == id);
            return View(cinema);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Cinema cinema)
        {
            dbcontext.Cinemas.Add(cinema);
            dbcontext.SaveChanges();
            //if (!ModelState.IsValid) 
            //{ 
            //    return View(actor); 
            //}
            //-service.Add(actor);

            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");

            }
            Cinema cinema = dbcontext.Cinemas.SingleOrDefault(c => c.Id == id);
            if (cinema == null)
            {
                return View("Done");
            }

            return View(cinema);
        }
        [HttpPost]
        public IActionResult Edit(Cinema cinema)
        {
            Cinema OldCinema = dbcontext.Cinemas.SingleOrDefault(c => c.Id == cinema.Id);


            OldCinema.Logo = cinema.Logo;
            OldCinema.Name = cinema.Name;
            OldCinema.Description = cinema.Description;

            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Cinema cinema = dbcontext.Cinemas.SingleOrDefault(c => c.Id == id);
            if (cinema == null)
            {
                return View("Done");
            }
            dbcontext.Cinemas.Remove(cinema);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
