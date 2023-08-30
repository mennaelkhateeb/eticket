using Microsoft.AspNetCore.Mvc;
using Ticket.Models;
using Tickets.Models;
using static Ticket.Models.myDbContext;

namespace Ticket.Controllers
{
    public class ProducerController : Controller
    {

        myDbContext dbcontext = new myDbContext();

        public IActionResult Index()
        {
            List<Producer> producers = dbcontext.Producers.ToList();
            return View(producers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Producer producer)
        {
            dbcontext.Producers.Add(producer);
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
            Producer producer = dbcontext.Producers.SingleOrDefault(c => c.Id == id);
            return View(producer);
        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");

            }
            Producer producer = dbcontext.Producers.SingleOrDefault(c => c.Id == id);
            if (producer == null)
            {
                return View("Done");
            }

            return View(producer);
        }
        [HttpPost]
        public IActionResult Edit(Producer producer)
        {
            Producer OldProducer = dbcontext.Producers.SingleOrDefault(c => c.Id == producer.Id);


            OldProducer.ProfilePictureURL = producer.ProfilePictureURL;
            OldProducer.FullName = producer.FullName;
            OldProducer.Bio = producer.Bio;

            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Producer producer = dbcontext.Producers.SingleOrDefault(c => c.Id == id);
            if (producer == null)
            {
                return View("Done");
            }
            dbcontext.Producers.Remove(producer);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
