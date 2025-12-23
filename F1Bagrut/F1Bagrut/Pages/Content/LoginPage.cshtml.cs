using F1Bagrut.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using System.Data;
using ServiceReference4;

namespace F1Bagrut.Pages.Content
{
    public class LoginPageModel : PageModel
    {
        [BindProperty]
        public string UserName { get; set; } = string.Empty;
        [BindProperty]
        public string Password { get; set; } = string.Empty;
        public DataTable dT { get; set; }
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

            ServiceReference4.Service1Client srv = new ServiceReference4.Service1Client();
            ServiceReference4.User user = new ServiceReference4.User();
            user.Username = UserName;
            user.Pass = Password;
            user.BirthYear = 7777;
            user.Tel = 2007;
            bool b = srv.AddUser(user);
            if (b)
                msg = "Added successfully";
            else
                msg = "Failed to add user";
            return Redirect("/Content/Index");
            //return Page();
        }

        public IActionResult OnPostAddDog()
        {
            ServiceReference4.Service1Client srv = new ServiceReference4.Service1Client();

            // 1. יצירת האובייקט (וודא שעשית Update Service Reference קודם)
            ServiceReference4.Dog dog = new ServiceReference4.Dog();

            // 2. מילוי נתונים (סתם נתונים לדוגמה כי אין input ב-HTML)
            dog.Name = UserName;
            dog.Age = 5;
            dog.Color = Password;

            // 3. שליחה לשירות
            bool result = srv.AddDog(dog);

            // 4. בדיקה אם הצליח
            if (result)
                msg = "Dog added successfully!";
            else
                msg = "Failed to add dog.";

            // נשאר באותו עמוד כדי לראות את ההודעה
            return Page();
        }

        public IActionResult OnPostAddCat()
        {
            ServiceReference4.Service1Client srv = new ServiceReference4.Service1Client();

            // 1. יצירת האובייקט
            ServiceReference4.Cat cat = new ServiceReference4.Cat();

            // 2. מילוי נתונים
            cat.Name = UserName;
            cat.Age = 3;
            cat.Color = Password;

            // 3. שליחה לשירות
            bool result = srv.AddCat(cat);

            // 4. בדיקה אם הצליח
            if (result)
                msg = "Cat added successfully!";
            else
                msg = "Failed to add cat.";

            return Page();
        }
    }
}