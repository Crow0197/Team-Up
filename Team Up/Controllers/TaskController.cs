﻿using System;
using System.Collections.Generic;
using System.IO;
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
            ViewBag.Reply = rl.GetReplyForTask(id).OrderByDescending(x => x.DateInsert);
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


            return RedirectToAction("Details", "Project", new { id = collection.Project });

        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)        {
            
            return View(tk.GetOne(id));
        }

        // POST: Task/Edit/5
        [HttpPost]
        public ActionResult Edit(TaskModel collection)
        {
            try
            {
                // TODO: Add update logic here

                tk.Edit(collection);

                return RedirectToAction("Details", new { id = collection.TaskID });
            }
            catch
            {
                return View();
            }
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            return View(tk.GetOne(id));
        }

        // POST: Task/Delete/5
        [HttpPost]
        public ActionResult Delete( TaskModel collection)
        {
            try
            {                // TODO: Add delete logic here

                var idP = collection.Project;
                tk.Delete(collection.TaskID);
                return RedirectToAction("Details", "Project", new { id = idP });
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file, int idTask)
        {

            try
            {

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var name = "File" + cookiemanagement.GetCoockieAustetication() + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + Path.GetExtension(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads"), name);
                    file.SaveAs(path);
                    ViewBag.Message = true;
                    ViewBag.Url = name;



                    return RedirectToAction("CreatFile", "Replys", new { TaskId = idTask, text = "../../Uploads/" + name });
                }
            }
            catch (ArgumentException e)
            {
                ViewBag.Message = false;
                return View();

            }




            return View();



        }


        public ActionResult CloseOrOpen(int id, bool isClose)
        {
            try
            {
                // TODO: Add delete logic here

                tk.CloseOrOpen(id, isClose);

                return RedirectToAction("Details", new { id = id });
            }
            catch
            {
                return RedirectToAction("Details",  new { id = id });
            }
        }


       
    }

}
