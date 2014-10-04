namespace PartyInvites.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using PartyInvites.Models;

    /// <summary>
    /// The home controller
    /// </summary>
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View();
        }

        // GET: RsvpForm
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        // POST: RsvpForm
        [HttpPost]
        public  ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                // TODO: Email notice to the organizer
                return View("Thanks", guestResponse);
            }
            else
            {
                // validation error...
                return View();
            }
        }
    }
}