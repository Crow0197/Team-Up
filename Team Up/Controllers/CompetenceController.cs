using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Team_Up.Controllers
{
    public class CompetenceController : Controller
    {
        // GET: Competence
        public ActionResult Index()
        {
            return View();
        }

        // GET: Competence/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Competence/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Competence/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Competence/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Competence/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Competence/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Competence/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
