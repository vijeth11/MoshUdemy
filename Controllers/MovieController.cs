using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Random()
        {
            var movie = new Movie() { Name="shrek"};
            var customers = new List<Customer> {
                new Customer{ Name = "Customer 1"},
                new Customer{ Name = "Customer 2"}
            };
            var randomMovieModel = new RandomMovieViewModel { movie = movie, customers = customers};
            return View(randomMovieModel);
            /* different returns */
            //return ContentResult("hello");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }

        public ActionResult Edit(int movieId)
        {
            // URLS when parameter name is id:
            // movie/edit/1
            // movie/edit?id=1
            // URLS when parameter name is movieId:
            // movie/edit?movieId=1
            return Content("id=" + movieId);
        }

        public ActionResult Index(int? pageNo, string sortBy)
        {
            // URLS
            // movie
            // movie?pageNo=1
            // movie?pageNo=1&sortBy=text
            if (!pageNo.HasValue)
                pageNo = 1;
            if (String.IsNullOrEmpty(sortBy))
                sortBy = "Name";
            return Content(String.Format("page number={0} and sort by = {1}",pageNo,sortBy));
        }

        [Route("movie/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(String.Format("{0}/{1}",year, month));
        }
    }
}