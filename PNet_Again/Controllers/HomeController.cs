using PNet_HomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PNet_Again.Controllers
{
    public class HomeController : Controller
    {
        private WorldContext _context;
        public HomeController()
        {
            _context = new WorldContext();
            //_context.Rivers.Add(new River()
            //{
            //    //Fishes = new List<Fish>(),
            //    RiverId = 5,
            //    Name = "Enisey",
            //});

            //_context.SaveChanges();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return RedirectToAction("Index", "Fish");
        }
    }
}
