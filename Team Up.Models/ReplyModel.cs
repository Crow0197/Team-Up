using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Team_Up.Models
{
    public class ReplyModel
    {
        public int TaskID { get; set; }
        public string UserName { get; set; }

        [Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm tt}")]
        public DateTime DateInsert { get; set; }

        [AllowHtml]
        public string Message { get; set; }

        public AccountModel AccountDetails { get; set; }

    }
}
