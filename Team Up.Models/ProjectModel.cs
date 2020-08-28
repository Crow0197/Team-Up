using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Up.Models
{
    public class ProjectModel
    {
        [Required]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        [Required]

        [DataType(DataType.Text)]
        public string Description { get; set; }

        public string CreatorAccount { get; set; }

        public List<CompetenceModel> Competences { get;set;}

        public List<CategoryModel> Categories { get; set; }

        public List<TaskModel> Tasks { get; set; }

        [DataType(DataType.Date)]
        public DateTime DtInsert { get; set; }

        public int ProjectID { get; set; }


        public string getCompetencesTostring() { 
       
            string getComp = "";
            foreach (var item in this.Competences)
            {
                getComp = item + ";";
            }
            return getComp;
        }

    }



}
