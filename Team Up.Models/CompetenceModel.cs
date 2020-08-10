using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Up.Models
{
   public class CompetenceModel
    {
        public string typology { get; set; }
        public int CompetenceID { get; set; }

        public string Color { get; set; }

        public bool Selected = false;
    }
}
