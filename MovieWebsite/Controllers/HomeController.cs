using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieWebsite.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieEntriesContext MovieContext { get; set; }


        public HomeController(ILogger<HomeController> logger, MovieEntriesContext movie)
        {
            _logger = logger;
            MovieContext = movie;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Movies()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Movies(Movies response)
        {
            MovieContext.Add(response);
            MovieContext.SaveChanges();
            return View("Confirmation");
        }
    }
}
