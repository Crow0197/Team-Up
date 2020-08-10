using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team_Up.BLL;
using Team_Up.Models;

namespace Team_Up.Controllers
{
    public class TaskController : Controller
    {

        TaskManagement tk;
        ReplyManagement rl;


        Cookie cookiemanagement = new Cookie();

        public TaskController()
        {
            this.tk = new TaskManagement();
            this.rl = new ReplyManagement();
        }


        // GET: Task
        public ActionResult Index()
        {           
            return PartialView("_Task", tk.GetAll());

        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.isLogin = cookiemanagement.GetCoockieAustetication();
            ViewBag.Reply = rl.GetReplyForTask(id).OrderByDescending(x=>x.DateInsert);
            return View(tk.GetOne(id));
        }

        // GET: Task/Create
        public ActionResult Create(int projectId = 1)
        {
            if (cookiemanagement.GetCoockieAustetication() != "")
            {

                ViewBag.NotLogin = false;
            }

            else
            {
                ViewBag.NotLogin = true;
            }



            ViewBag.Project = projectId;
            return View();
        }

        // POST: Task/Create
        [HttpPost]
        public ActionResult Create(TaskModel collection)
        {
           
                collection.AccountCreator = cookiemanagement.GetCoockieAustetication();
                tk.Create(collection);


                return RedirectToAction("Details", "Project", new { id = collection.Project});

        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Task/Edit/5
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

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Task/Delete/5
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
