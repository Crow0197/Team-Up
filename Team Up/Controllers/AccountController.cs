using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Team_Up.BLL;
using Team_Up.Models;
using Team_Up.ViewModels;

namespace Team_Up.Controllers
{
    public class AccountController : Controller
    {
        AccountManagement am;
        ProjectManagement pm;
        CompentenceManagement cm;



        Cookie cookiemanagement = new Cookie();

        public AccountController()
        {
            this.am = new AccountManagement();
            this.cm = new CompentenceManagement();
            this.pm = new ProjectManagement();

        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: Account/Details/5


        public ActionResult myAccount()
        {
            ViewBag.Error = false;


            var loginUser = cookiemanagement.GetCoockieAustetication();

            if (loginUser == "")
            {

                return RedirectToAction("Login");
            }

            else
            {
                ViewBag.Compentence = cm.getAllForAccount(loginUser);
                return View(am.GetAccountForUsername(cookiemanagement.GetCoockieAustetication()));
            }




        }



        public ActionResult ViewAccount(string Username)
        {
            ViewBag.Compentence = cm.getAllForAccount(Username);
            return View(am.GetAccountForUsername(Username));

        }




        // GET: Account/Create
        public ActionResult Create()
        {
            IList<CompetenceModel> listCompetence = new List<CompetenceModel>();
            listCompetence = cm.getAll();


            ViewBag.ListCompetence = listCompetence;



            return View();
        }

        // POST: Account/Create
        [HttpPost]
        public ActionResult Create(AccountModel newAccount, int[] Compentecey)
        {

            ViewBag.NotLogin = true;
            ViewBag.success = true;

            // TODO: Add insert logic here

            var success = am.Registration(newAccount, Compentecey);

            if (success)
            {
                cookiemanagement.CoockieCrationOfAustetication(newAccount.UserName);
                return RedirectToAction("UploadAvatar");
            }

            else
            {
                ViewBag.success = false;
                IList<CompetenceModel> listCompetence = new List<CompetenceModel>();
                listCompetence = cm.getAll();
                ViewBag.ListCompetence = listCompetence;
                return View(newAccount);
            }

        }

        // GET: Account/Edit/5
        public ActionResult Edit(int? id)
        {
            var usernLogin = cookiemanagement.GetCoockieAustetication();
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

        // POST: Account/Edit/5
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

            return RedirectToAction("Edit", "Account", new { username = collection.UserName });


        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
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




        public ActionResult UploadAvatar(string urlImg = "")

        {
            var user = cookiemanagement.GetCoockieAustetication();
            if (user != "")
            {
                ViewBag.Url = am.GetAccountForUsername(user).Avatar;
                ViewBag.NotLogin = false;
            }

            else
            {
                ViewBag.NotLogin = true;
            }


            return View();
        }


        [HttpPost]
        public ActionResult UploadAvatar(HttpPostedFileBase file)
        {

            try
            {

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var name = "Account" + cookiemanagement.GetCoockieAustetication() + Path.GetExtension(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads"), name);
                    file.SaveAs(path);
                    ViewBag.Message = true;
                    ViewBag.Url = name;

                    am.ChangeAvatar(cookiemanagement.GetCoockieAustetication(), name);

                    return View();
                }
            }
            catch (ArgumentException e)
            {
                ViewBag.Message = false;
                return View();

            }




            return View();
        }





        public ActionResult Login()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Login(ViewModelLogin newAccount)
        {
            var username = newAccount.Username;

            ViewBag.success = true;
            try
            {
                if (am.LoginCertification(newAccount.Username, newAccount.Password))
                {
                    cookiemanagement.CoockieCrationOfAustetication(username);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.success = false;
                    return View();
                }

            }
            catch (ArgumentException e)
            {
                return View();
            }
        }



        public ActionResult Logout()
        {
            cookiemanagement.DeletCoockieAustetication();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult PasswordRecovery()
        {

            return View();
        }


        // POST: Account/Create
        [HttpPost]
        public ActionResult PasswordRecovery(string email)
        {

            if (am.PasswordRecovery(Url.Action("ChangePassword", "Account"), email))
            {

                ViewBag.Error = false;


            }
            else ViewBag.Error = true;


            return View();
        }


        public ActionResult ChangePassword(string user)
        {
            if (user == null) { user = cookiemanagement.GetCoockieAustetication(); }
            ViewBag.User = user;
            return View();
        }



        [HttpPost]
        public ActionResult ChangePassword(FormCollection collection)
        {
            ViewBag.Error = true;

            if (am.ChangePassword(collection["User"], collection["password"]) == true) { return RedirectToAction("Login"); }

            return View();


        }

        public ActionResult ProjectForAccount()
        {

            var loginUser = cookiemanagement.GetCoockieAustetication();



            List<ProjectModel> projectModels = new List<ProjectModel>();



            ViewBag.MyProject = pm.getAll().Where(x => x.CreatorAccount == loginUser).ToList();
            ViewBag.SignedUpProject = pm.getSignedUpProject(loginUser);



            return View();

        }

    }
}
