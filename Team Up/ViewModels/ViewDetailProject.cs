﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team_Up.Models;

namespace Team_Up.ViewModels
{
    public class ViewDetailProject
    {
        public IList<CompetenceModel> Competences { get; set; }
        public IList<CategoryModel> Categories { get; set; }
        public IList<TaskModel> Tasks { get; set; }
        public ProjectModel Project { get; set; }
    }
}