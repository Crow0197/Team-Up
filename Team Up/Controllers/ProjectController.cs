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
        AccountManagement am;


        public ProjectController(){
            this.pm = new ProjectManagement();
            this.cm = new CompentenceManagement();
            this.categoryM = new CategoryManagement();
            this.tk = new TaskManagement();
            this.am = new AccountManagement();
        }


        // GET: Project
        [HttpGet]
        public ActionResult Index(int[] Compentecey, int[] CategoryFilter, DateTime? dataCreate, int? id, int? Competence,int? Category, int pageIndex = 1, string progetto = "", string parolachiave="", string autore = "")
        {
           
            List<ProjectModel> getList = new List<ProjectModel>();

            getList = pm.getAll();
                                   
           
            if (progetto != ViewBag.Progetto)
            {
                ViewBag.Progetto = progetto;

            }

            if (progetto != "") {
                getList = getList.Where(x=> x.Title.Contains(progetto)).ToList();

            }


           


            if (parolachiave != ViewBag.Descrizione)
            {
                ViewBag.Descrizione = parolachiave;
            }
            if (parolachiave != "")
            {
                getList = getList.Where(x => x.Description.Contains(parolachiave)).ToList();

            }



            if (autore != ViewBag.Autore)
            {
                ViewBag.Autore = autore;
            }
            if (autore != "")
            {
                getList = getList.Where(x => x.CreatorAccount.Contains(autore)).ToList();

            }



            if (dataCreate != ViewBag.DataCreate)
            {
                ViewBag.DataCreate = dataCreate;
            }
            if (dataCreate != null)
            {                
                getList = getList.Where(x => x.Date == dataCreate).ToList();

            }





            ViewBag.ListCompetence = cm.getAll();

            if (Compentecey != null   ) { 
            foreach (var item in ViewBag.ListCompetence)
            {
                if (Compentecey.Any(x => x == item.CompetenceID))
                {
                    item.Selected = true;
                }

            }


                foreach (var item in Compentecey)
                {
                    getList = getList.Where(x => x.Competences.Any(y => y.CompetenceID == item)).ToList();
                }
              
            }



            ViewBag.ListCategory = categoryM.getAll();

            if (CategoryFilter != null)
            {
                foreach (var item in ViewBag.ListCategory)
                {
                    if (CategoryFilter.Any(x => x == item.CategoryID))
                    {
                        item.Selected = true;
                    }

                }


                foreach (var item in CategoryFilter)
                {
                    getList = getList.Where(x => x.Categories.Any(y => y.CategoryID == item)).ToList();
                }

            }









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




            int pageSize = 6;
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
            ViewBag.isRegistered = pm.isRegistered(id, cookiemanagement.GetCoockieAustetication());
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
            ProjectModel project = new ProjectModel();


            IList<CompetenceModel> allCompetence = new List<CompetenceModel>();
            allCompetence = cm.getAll();

            IList<CompetenceModel> userCompetence = new List<CompetenceModel>();
            userCompetence = cm.getAllForProject(id);


            foreach (var item in allCompetence)
            {
                if (userCompetence.Any(x => x.CompetenceID == item.CompetenceID))
                {
                    item.Selected = true;
                }

            }

            ViewBag.ListCompetence = allCompetence;


            IList<CategoryModel> allCategory = new List<CategoryModel>();
            allCategory = categoryM.getAll();

            IList<CategoryModel> userCategory = new List<CategoryModel>();
            userCategory = categoryM.getAllForProject(id);


            foreach (var item in allCategory)
            {
                if (userCategory.Any(x => x.CategoryID == item.CategoryID))
                {
                    item.Selected = true;
                }

            }

            ViewBag.ListCategory = allCategory;



            ViewBag.Task = tk.GetFromProject(id);
            // project = pm.;
            return View(pm.getOne(id));
        }

        // POST: Project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, int[] Compentece, int[] Category)
        {
            try
            {
                ProjectModel project = new ProjectModel();

                project.Title = collection["Title"];
                project.Date = collection["Date"].AsDateTime();
                project.Description = collection["Description"];
                project.ProjectID = collection["ProjectID"].AsInt();
                project.DtInsert = DateTime.Now;
                project.CreatorAccount = cookiemanagement.GetCoockieAustetication();
                pm.Update(project, Compentece, Category);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: Project/Edit/5
        public ActionResult SignedUpProject(int projectID)
        {
            AccountModel creator = new AccountModel();
            creator = am.GetAccountForUsername(pm.getOne(projectID).CreatorAccount);

            AccountModel user = new AccountModel();
            user = am.GetAccountForUsername(cookiemanagement.GetCoockieAustetication());

            pm.SignedUp(projectID, creator, user);
            return RedirectToAction("Index");

        }


        public ActionResult AcceptRegistration(int idSignedUp, bool accepted)
        {
            pm.AcceptRegistration(idSignedUp, accepted);
            return RedirectToAction("Index");

        }


        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            return View(pm.getOne(id)); ;
        }

        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
           
                pm.Delete(id);

                return RedirectToAction("Index");
           
        }



    }
}
