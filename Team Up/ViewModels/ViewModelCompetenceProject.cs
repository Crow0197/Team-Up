using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team_Up.Models;

namespace Team_Up.ViewModels
{
    public class ViewModelCompetenceProject
    {
        public IList<CompetenceModel> Competences { get; set; }
        public ProjectModel project { get; set; }

    }
}