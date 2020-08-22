using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team_Up.BLL;
using Team_Up.DAL;
using Team_Up.DAL.EF;
using Team_Up.Entities;
using Team_Up.Models;

namespace Team_Up
{
    public class CategoryManagement
    {
        IRepositoryCategory categoryRepository = new RepositoryCategory();


        public List<CategoryModel> getAll()
        {
            
            Mapping mapping = new Mapping();
            List<CategoryModel> categories = new List<CategoryModel>();

            var getDB = categoryRepository.GetAll();

            

            if (getDB.Count != 0) {
                foreach (var item in getDB)
                {
                    CategoryModel category = new CategoryModel();
                    mapping.MapObjects(item, category);
                    categories.Add(category);
                }           
            }          

            return categories;
        }


        public CategoryModel getOne(int id)
        {
            CategoryModel categoryReturn = new CategoryModel();
            var returnDB = categoryRepository.GetOne(id);
            if(returnDB != null)
            {
                Mapping mapping = new Mapping();
                mapping.MapObjects(returnDB, categoryReturn);
            }

            return categoryReturn;
        }


        public void Delete(int id) {

            categoryRepository.Delete(id);
        }


        public List<CategoryModel> getAllForProject(int id)
        {

            Mapping mapping = new Mapping();
            List<CategoryModel> Models = new List<CategoryModel>();
            var categoryDB = categoryRepository.getAllForProject(id);

            if (categoryDB.Count != 0)
            {
                foreach (var item in categoryDB)
                {
                    CategoryModel ct = new CategoryModel();
                    mapping.MapObjects(item, ct);
                    Models.Add(ct);
                }
            }

            return Models;
        }


        public void Create(CategoryModel cm)
        {

            Mapping mapping = new Mapping();
            Category category = new Category();
            mapping.MapObjects(cm, category);
            categoryRepository.Create(category);


        }

    }
}