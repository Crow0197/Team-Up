using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Up.Models
{
   public class CompetenceModel
    {

        [Display(Name = "Tipologia")]
        public string typology { get; set; }
        public int CompetenceID { get; set; }
        [Display(Name = "Classe")]
        public string Color { get; set; }

        public bool Selected = false;
    }
}
