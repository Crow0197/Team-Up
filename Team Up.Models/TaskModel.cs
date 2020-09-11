using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Up.Models
{
    public class TaskModel
    {
        public int TaskID { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Chiuso ?")]
        public bool isClosed { get; set; }

        [Display(Name = "Data Inizio")]
        [Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateInsert { get; set; }

        [Display(Name = "Data Chiusura")]
        [Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DateClose { get; set; }
        public int Project { get; set; }

        [Display(Name = "Creatore")]
        public string AccountCreator { get; set; }

        [Display(Name = "Descrizione")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

    }
}
