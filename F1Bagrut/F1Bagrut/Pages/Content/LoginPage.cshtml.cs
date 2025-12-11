using F1Bagrut.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using System.Data;
using ServiceReference3;

namespace F1Bagrut.Pages.Content
{
    public class LoginPageModel : PageModel
    {
        [BindProperty]
        public string UserName { get; set; } = string.Empty;
        [BindProperty]
        public string Password { get; set; } = string.Empty;
        public DataTable dT {  get; set; }
        public string msg { get; set; } = string.Empty;
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            //Helper helper = new Helper();
            //string strsql = $"SELECT * FROM UsersTB WHERE userName = '{UserName}' AND password = '{Password}'";
            //dT = helper.RetrieveTable(strsql, "usersTB");
            //if(dT.Rows.Count > 0 ) 
            //    {    
            //        HttpContext.Session.SetString("Login", UserName);
            //        HttpContext.Session.SetString("Admin", dT.Rows[0]["admin"].ToString());

            //        return Redirect("/Index");
            //    }
            //msg = "Wrong user name or password";
            ServiceReference3.Service1Client srv = new ServiceReference3.Service1Client();
            ServiceReference3.User user = new ServiceReference3.User();
            user.Username = UserName;
            user.Pass = Password;
            user.BirthYear = 7777;
            user.Tel = 2007;
            bool b = srv.AddUser(user);
            
            if(b)
                msg = "Added successfully";
            else
                msg = "Failed to add user";
            return Redirect("/Content/Index");
            //return Page();
        }
    }
}
