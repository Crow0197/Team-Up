using System;
using System.Collections.Generic;
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
        public DateTime DateInsert { get; set; }
        public DateTime? DateClose { get; set; }

    }
}
