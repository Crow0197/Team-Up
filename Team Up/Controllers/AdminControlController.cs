using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using Team_Up.BLL;
using Team_Up.Models;

namespace Team_Up.Controllers
{
    public class AdminControlController : Controller
    {
        AccountManagement am;
        CompentenceManagement cm;
        CategoryManagement cam;
        Cookie cookiemanagement = new Cookie();   


        public AdminControlController()
        {
            this.am = new AccountManagement();
            this.cm = new CompentenceManagement();
            this.cam = new CategoryManagement();


        }
        // GET: Admin
        public ActionResult AdminControl()
        {
            if (cookiemanagement.GetCoockieAustetication() == "Admin")
            {
                ViewBag.Accounts = am.getAll();
                ViewBag.Compences = cm.getAll();
                ViewBag.Categories = cam.getAll();
                return View();
            }

            return RedirectToAction("Login","Account");

        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
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

        // GET: Admin/Edit/5
        public ActionResult Edit(string username)
        {
            var usernLogin = username;
            var utente = am.GetAccountForUsername(usernLogin);

            IList<CompetenceModel> allCompetence = new List<CompetenceModel>();
            allCompetence = cm.getAll();

            IList<CompetenceModel> userCompetence = new List<CompetenceModel>();
            userCompetence = cm.getAllForAccount(usernLogin);


            foreach (var item in allCompetence)
            {
                if (userCompetence.Any(x => x.CompetenceID == item.CompetenceID))
                {
                    item.Selected = true;
                }

            }

            ViewBag.ListCompetence = allCompetence;


            if (usernLogin != "")
            {

                ViewBag.NotLogin = false;
            }

            else
            {
                ViewBag.NotLogin = true;
            }


            return View(utente);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(AccountModel collection, int[] Compentecey)
        {
            try
            {
                am.EditAccount(collection, Compentecey);
                ViewBag.success = true;
            }
            catch
            {
                ViewBag.success = false;
            }

            return RedirectToAction("Edit", new { username = collection.UserName });
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(string username)
        {
            var utente = am.GetAccountForUsername(username);
            return View(utente);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                  am.Delete(id);   
                return RedirectToAction("AdminControl");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult DetailsCompentece(int id)
        {
            return PartialView("_DetailsCompentece", cm.getAll());
           
        }


        // GET: Admin/Delete/5
        public ActionResult DeleteCompetence(int CompetenceID)
        {
            var utente = cm.getOneCompetenc(CompetenceID);
            return View(utente);
        }


        [HttpPost]
        public ActionResult DeleteCompetence(FormCollection collection)
        {
            try
            {
                cm.Delete(collection["CompetenceID"].AsInt());
                return RedirectToAction("AdminControl");
            }
            catch
            {
                return View();
            }
        }






        // GET: Admin/Create
        public ActionResult CreateCompentece()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult CreateCompentece(CompetenceModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                cm.Create(collection);
                return RedirectToAction("AdminControl");
            }
            catch
            {
                return View();
            }
        }



        // GET: Admin/Delete/5
        public ActionResult DeleteCategories(int CategoryID)
        {
            var cm = cam.getOne(CategoryID);
            return View(cm);
        }


        [HttpPost]
        public ActionResult DeleteCategories(FormCollection collection)
        {
            try
            {
                cam.Delete(collection["CategoryID"].AsInt());
                return RedirectToAction("AdminControl");
            }
            catch
            {
                return View();
            }
        }



    }
}
