using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Team_Up.Models
{
    public class CategoryModel
    {
        [Display(Name = "Tipologia")]
        public string Typology { get; set; }
        public int CategoryID { get; set; }

        [Display(Name = "Classe")]
        public string Color { get; set; }

        public bool Selected = false;


    }
}


