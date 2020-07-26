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

        Cookie cookiemanagement = new Cookie();

        public AccountController()
        {
            this.am = new AccountManagement();
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
            
            if (loginUser == "") {

                return RedirectToAction("Login");
            }

        else return View(am.GetAccountForUsername(cookiemanagement.GetCoockieAustetication()));





        }



        // GET: Account/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Account/Create
        [HttpPost]
        public ActionResult Create(AccountModel newAccount)
        {
            ViewBag.success = true;

            try
            {
                // TODO: Add insert logic here

                var success = am.Registration(newAccount);

                if (success)
                {
                    cookiemanagement.CoockieCrationOfAustetication(newAccount.UserName);
                    return RedirectToAction("UploadAvatar");
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

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("UploadAvatar");
            }
            catch
            {
                return View();
            }
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
            if (cookiemanagement.GetCoockieAustetication() != "")
            {

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



    }
}
