using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Team_Up.BLL
{
    public class Cookie
    {

        public void CoockieCrationOfAustetication(string account = "")
        {                        
            // Get cookie from the current request.
            HttpCookie cookie = HttpContext.Current.Request.Cookies.Get("UserLogin");
            // Check if cookie exists in the current request.           
                // Create cookie.
                cookie = new HttpCookie("UserLogin");
                cookie.Value = account;
                cookie.Expires = DateTime.Now.AddMinutes(1d);
                HttpContext.Current.Response.Cookies.Add(cookie);
            
        }


        public string GetCoockieAustetication()
        {

            string returnUsername = "";

            // Get cookie from the current request.
            HttpCookie cookie = HttpContext.Current.Request.Cookies.Get("UserLogin");
            // Check if cookie exists in the current request.

            if (cookie != null)
            {               
                returnUsername = cookie.Value;                
            }


            return returnUsername;


        }



        public void DeletCoockieAustetication()
        {
            HttpContext.Current.Response.Cookies["UserLogin"].Expires = DateTime.Now.AddDays(-1);
         }





    }
}
