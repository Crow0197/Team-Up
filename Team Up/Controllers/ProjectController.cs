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
    public class ProjectController : Controller
    {
        Cookie cookiemanagement = new Cookie();

        ProjectManagement pm;
        CompentenceManagement cm;
        CategoryManagement categoryM;
        TaskManagement tk;


        public ProjectController(){
            this.pm = new ProjectManagement();
            this.cm = new CompentenceManagement();
            this.categoryM = new CategoryManagement();
            this.tk = new TaskManagement();
        }


        // GET: Project
        [HttpGet]
        public ActionResult Index(int? id, int? Competence,int? Category, int pageIndex = 1)
        {

            List<ProjectModel> getList = new List<ProjectModel>();

            getList = pm.getAll();

            if (id != 0 && id !=null) {
                getList = getList.Where(x=> x.ProjectID == id).ToList();
            }

            if (Category != null)
            {

                var idToDelete = new List<int>();
             

                foreach (var item in getList)
                {
                    var dss = item.Categories.FirstOrDefault(x=> x.CategoryID == Category);
                    if (dss == null) {
                        idToDelete.Add(item.ProjectID);
                    }
                }

                foreach (var item in idToDelete)
                {
                    var idelete = getList.First(x => x.ProjectID == item);
                    getList.Remove(idelete); 
                }



            }



            if (Competence != null)
            {

                var idToDelete = new List<int>();


                foreach (var item in getList)
                {
                    var dss = item.Competences.FirstOrDefault(x => x.CompetenceID == Competence);
                    if (dss == null)
                    {
                        idToDelete.Add(item.ProjectID);
                    }
                }

                foreach (var item in idToDelete)
                {
                    var idelete = getList.First(x => x.ProjectID == item);
                    getList.Remove(idelete);
                }



            }




            int pageSize = 3;
            ViewBag.PageIndex = pageIndex;
            var totalItems = getList.Count();
            var totalPages = (totalItems / pageSize) + 1;
            if (totalItems % pageSize == 0) totalPages--;

            ViewBag.TotalPages = totalPages;
            ViewBag.TotalItems = totalItems;

            return View(getList.Skip(pageSize * (pageIndex - 1)).Take(pageSize));
            
        }

        // GET: Project/Details/5
     
        public ActionResult Details(int id)
        {


            ProjectModel project = new ProjectModel();

            ViewBag.Task = tk.GetFromProject(id);
           // project = pm.;
            return View(pm.getOne(id));
        }

        // GET: Project/Create
        public ActionResult Create()
        {

            ViewBag.NotLogin = true;
            IList<CompetenceModel> listCompetence = new List<CompetenceModel>();

            listCompetence = cm.getAll();


            IList<CategoryModel> listCategory = new List<CategoryModel>();
            listCategory = categoryM.getAll();




            if (cookiemanagement.GetCoockieAustetication() != "")
            {
                var loginUser = cookiemanagement.GetCoockieAustetication();
                if (loginUser == "")
                {
                    return RedirectToAction("Login");
                }

                ViewBag.ListCompetence = listCompetence;
                ViewBag.ListCategory = listCategory;
                ViewBag.NotLogin = false;
            }
            else
            {
                ViewBag.NotLogin = true;
            }

            ViewBag.ListCompetence = listCompetence;
            ViewBag.ListCategory = listCategory;
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, int[] Compentece, int[] Category)
        {
            try
            {
                // TODO: Add insert logic here
                              

                ProjectModel project = new ProjectModel();

                project.Title = collection["Title"];
                project.Date = collection["Date"].AsDateTime();
                project.Description = collection["Description"];
                project.DtInsert = DateTime.Now;
                project.CreatorAccount = cookiemanagement.GetCoockieAustetication();


                pm.Create(project, Compentece, Category);
                return RedirectToAction("Index");
            }
            catch (ArgumentException e)
            {
                return View();
            }
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Project/Edit/5
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

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Project/Delete/5
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
