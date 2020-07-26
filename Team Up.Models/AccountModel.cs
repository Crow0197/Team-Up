using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Team_Up.Models
{
    public class AccountModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        [Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string TypeAccount { get; set; }
        public HttpPostedFileBase File { get; set; }

        public string UserName { get; set; }

        public string Avatar { get; set; }



    }
}
