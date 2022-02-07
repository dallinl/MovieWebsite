using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private MovieEntriesContext MovieContext { get; set; }


        public HomeController(MovieEntriesContext movie)
        {
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
            ViewBag.Categories = MovieContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Movies(Movies response)
        {
            if (ModelState.IsValid)
            {
                MovieContext.Add(response);
                MovieContext.SaveChanges();
                return View("Confirmation", response);
            }

            else
            {
                ViewBag.Categories = MovieContext.Categories.ToList();
                return View(response);
            }

        }
        [HttpGet]
        public IActionResult AllMovies ()
        {

            var movies = MovieContext.movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit (int movieid)
        {
            ViewBag.Categories = MovieContext.Categories.ToList();

            var movie = MovieContext.movies.Single(x => x.MovieID == movieid);

            return View("Movies", movie);
        }

        [HttpPost]
        public IActionResult Edit (Movies m)
        {
            MovieContext.Update(m);
            MovieContext.SaveChanges();
            return RedirectToAction("AllMovies");
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = MovieContext.movies.Single(x => x.MovieID == movieid);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(Movies movie)
        {
            MovieContext.movies.Remove(movie);
            MovieContext.SaveChanges();
            return RedirectToAction("AllMovies");
        }

    }
}
