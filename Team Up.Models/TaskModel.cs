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
        public string Name { get; set; }
        public bool isClosed { get; set; }

        [Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateInsert { get; set; }

        [Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DateClose { get; set; }
        public int Project { get; set; }
        public string AccountCreator { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

    }
}
