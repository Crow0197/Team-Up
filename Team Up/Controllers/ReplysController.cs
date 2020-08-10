using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team_Up.BLL;
using Team_Up.Models;

namespace Team_Up.Controllers
{
    public class ReplysController : Controller
    {
        // GET: Replys

        Cookie cookiemanagement = new Cookie();

        ReplyManagement replM = new ReplyManagement();


        public ActionResult Index()
        {
            return View();
        }

        // GET: Replys/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Replys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Replys/Create
        [HttpPost]
        public ActionResult Create(ReplyModel collection)
        {
            try
            {
                collection.UserName = cookiemanagement.GetCoockieAustetication();
                collection.DateInsert = DateTime.Now;


                replM.Create(collection);

                return RedirectToAction("Details", "Task", new { id = collection.TaskID });

            }
            catch
            {
                return View();
            }
        }

        // GET: Replys/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Replys/Edit/5
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

        // GET: Replys/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Replys/Delete/5
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
