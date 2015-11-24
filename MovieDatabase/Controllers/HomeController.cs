using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MovieDatabase.Models;

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        private MoviesDBEntities db = new MoviesDBEntities();
        //
        // GET: /Home/ 
        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }
        //
        // GET: /Home/Details/5 
        public ActionResult Details(int id)
        {
            return View();
        }
        //

        // GET: /Home/Create 
        public ActionResult Create()

        {

            return View();

        }

        //

        // POST: /Home/Create 

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude = "Id")] Movies movieToCreate)

        {

            if (!ModelState.IsValid)
            {
                return View();
            }


            db.Movies.Add(new Movies(){ 
                Title = movieToCreate.Title,
                Synopsis = movieToCreate.Synopsis,
                Year = movieToCreate.Year});

            db.SaveChanges();

            return RedirectToAction("Index");

        }

        //

        // GET: /Home/Edit/5

        public ActionResult Edit(int id)

        {

            var movieToEdit = (from m in db.Movies

                               where m.Id == id

                               select m).First();

            return View(movieToEdit);

        }

        //

        // POST: /Home/Edit/5 

        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Edit(Movies movieToEdit)

        {

            var originalMovie = (from m in db.Movies

                                 where m.Id == movieToEdit.Id

                                 select m).First();

            if (!ModelState.IsValid)

                return View(originalMovie);

            originalMovie.Synopsis = movieToEdit.Synopsis;
            originalMovie.Title = movieToEdit.Title;
            originalMovie.Year = movieToEdit.Year;

            db.SaveChanges();

            return RedirectToAction("Index");

        }

    }

}