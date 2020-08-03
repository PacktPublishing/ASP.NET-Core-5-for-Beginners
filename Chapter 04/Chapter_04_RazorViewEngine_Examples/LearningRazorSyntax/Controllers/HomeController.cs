using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Chapter_04_LearningRazorSyntax.Models;

namespace Chapter_04_LearningRazorSyntax.Controllers
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "Razor is Awesome!";

            var beer = new Beer();
            var listOfBeers = beer.GetAllBeer();
            return View(listOfBeers);
        }

        public IActionResult IndexNew()
        {
            var beer = new Beer();
            //returning only the first row
            var listOfBeers = beer.GetAllBeer().FirstOrDefault();
            return View(listOfBeers);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


