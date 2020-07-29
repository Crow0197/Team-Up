﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Up.Entities;

namespace Team_Up.DAL
{
    public interface IRepositoryProject
    {
        Project GetOne(int idSearch);

        Project GetOne(string Username);
        void Update(Project project);
        Boolean Delete(Project project);
        List<Project> GetAll();
        bool Create(Project project, string account, int[] competence, int[] category);
        void Save();

    }


}
