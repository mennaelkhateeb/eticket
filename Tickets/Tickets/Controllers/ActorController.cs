using Microsoft.AspNetCore.Mvc;
using Ticket.Models;
using Tickets.Models;

namespace Ticket.Controllers
{
    public class ActorController : Controller
    {
        myDbContext dbcontext = new myDbContext();

        public IActionResult Index()
        {
            List<Actor>actors = dbcontext.Actors.ToList();
            
            return View(actors);
        }

        //public IActionResult Details(int id)
        //{
        //    Actor actor = dbcontext.Actors.SingleOrDefault(c =>c.Id == id);
        //    return View(actor);
        //}
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public  IActionResult Create(Actor actor)
        {
            dbcontext.Actors.Add(actor);
            dbcontext.SaveChanges();
            //if (!ModelState.IsValid) 
            //{ 
            //    return View(actor); 
            //}
            //-service.Add(actor);

            return RedirectToAction("Index");   
           
        }

        public IActionResult Details(int id)
        {
            Actor actor = dbcontext.Actors.SingleOrDefault(c => c.Id == id);
            return View(actor);
            

        }

        public IActionResult Edit(int id)
        {
            if(id == null)
            {
                return RedirectToAction("Index");

            }
            Actor actor = dbcontext.Actors.SingleOrDefault(c => c.Id == id);
            if(actor == null)
            {
                return View("Done");
            }

            return View(actor);
        }
        [HttpPost]
        public IActionResult Edit(Actor actor)
        {
            Actor OldActor = dbcontext.Actors.SingleOrDefault(c => c.Id == actor.Id);

            
            OldActor.ProfilePictureURL = actor.ProfilePictureURL;
            OldActor.FullName = actor.FullName;
            OldActor.Bio= actor.Bio;

            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public IActionResult Delete(int id)
        {
            Actor actor=dbcontext.Actors.SingleOrDefault(c => c.Id == id);  
            if(actor == null)
            {
                return View("Done");
            }
            dbcontext.Actors.Remove(actor);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
