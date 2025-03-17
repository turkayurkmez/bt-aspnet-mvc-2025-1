using introduceMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace introduceMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //Html, CSS, JavaScript
            //404 Not Found
            //Json
            //File
            //Redirect


            ViewBag.Tarih = DateTime.Now;

            ViewBag.Ad = "Türkay Ürkmez";

            var people = new List<Person>
            {
                new Person { Id = 1, Name = "Türkay", Surname = "Ürkmez", Email = "tu@gmail.com" },
                new Person { Id = 2, Name = "Ali", Surname = "Veli", Email = "av@gmail.com" },
                new Person { Id = 3, Name = "Ayşe", Surname = "Fatma", Email = "af@gmail.com" }
            };

            return View(people);
        }

        public IActionResult Response()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Response(Person person)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks",person);
            }

            return View();

        }
    }
}
