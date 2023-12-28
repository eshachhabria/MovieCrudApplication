using MovieCrudApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieCrudApplication.Controllers
{
    public class DefaultController : Controller
    {
        MVC_DBEntities _context = new MVC_DBEntities();
        // GET: Default
        public ActionResult Index()
        {
            var listofdata = _context.Movies.ToList()
;            return View(listofdata);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(Movie model)
        {
            _context.Movies.Add(model);
            _context.SaveChanges();
            ViewBag.massage = "Data Inserted Successfully";
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Movies.Where(x => x.movie_id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Movie model)
        {
            var data = _context.Movies.Where(x => x.movie_id == model.movie_id).FirstOrDefault();
            if (data != null)
            {
                data.movie_id = model.movie_id;
                data.movie_name = model.movie_name;
                data.movie_rating = model.movie_rating;
                data.movie_language = model.movie_language;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var data = _context.Movies.Where(x => x.movie_id == id).FirstOrDefault();
            return View(data);
        }
        public ActionResult Delete(int id)
        {
            var data = _context.Movies.Where(x => x.movie_id == id).FirstOrDefault();
            _context.Movies.Remove(data);
            _context.SaveChanges();
            ViewBag.message = "Record delete successfully";
            return RedirectToAction("Index");

        }



    }
}