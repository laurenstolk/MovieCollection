using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieCollection.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieCollection.Controllers
{
    public class HomeController : Controller
    {

        private MovieEntryContext daContext { get; set; }

        // Constructor
        public HomeController(MovieEntryContext someName)
        {
            daContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View("MyPodcasts");
        }

        [HttpGet]
        public IActionResult MovieEntry()
        {
            ViewBag.Categories = daContext.Categories.ToList();
          
            return View();
        }

        [HttpPost]
        public IActionResult MovieEntry(EntryResponse er)
        {
            if (ModelState.IsValid)
            {
                daContext.Add(er);
                daContext.SaveChanges();

                return View("Confirmation", er);
            }
            else // if invalid
            {
                ViewBag.Categories = daContext.Categories.ToList();
                return View(er);
            }

        }

        [HttpGet]
        public IActionResult MovieList()
        {
            var entries = daContext.Responses
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(entries);
        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = daContext.Categories.ToList();

            var entry = daContext.Responses.Single(x => x.MovieID == movieid);

            return View("MovieEntry", entry);
        }

        [HttpPost]
        public IActionResult Edit(EntryResponse er)
        {
            daContext.Update(er);
            daContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var entry = daContext.Responses.Single(x => x.MovieID == movieid);

            return View(entry);
        }

        [HttpPost]
        public IActionResult Delete(EntryResponse er)
        {
            daContext.Responses.Remove(er);
            daContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

    }
}
