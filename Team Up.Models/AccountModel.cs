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

        public int AccountID { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Cognome")]
        public string Surname { get; set; }
        [Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]

        [Display(Name = "Data Di Nascità")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"\S+@\S+\.\S+", ErrorMessage = "Si prega di inserire un indirizzo email valido.")]
        [Required]

        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Deve contenere tra 5 e 255 caratteri", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]

        [Display(Name = "Conferma Pass")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Tipo Account")]
        public string TypeAccount { get; set; }
        public HttpPostedFileBase File { get; set; }

        public string UserName { get; set; }

        public string Avatar { get; set; }



    }
}
