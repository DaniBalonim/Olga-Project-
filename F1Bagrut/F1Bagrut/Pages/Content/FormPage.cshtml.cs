using F1Bagrut.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace F1Bagrut.Pages.Content
{
    public class FormPageModel : PageModel
    {
        public string msg { get; set; } = string.Empty;
        [BindProperty]
        public User NewUser { get; set; } = new User();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            //Helper helper = new Helper();
            //int n = helper.Insert(NewUser, "usersTB");
            //if (n == -1)
            //{
            //    msg = "User already taken";
            //    return Page();
            //}
            //return RedirectToPage("Index");

            ServiceReference.Service1Client srv = new ServiceReference.Service1Client();
            ServiceReference.User user = new ServiceReference.User();
            user.Username = NewUser.userName;
            user.Pass = NewUser.password;
            user.BirthYear = NewUser.birthDay;
            user.Tel = 1234;
            bool b = srv.AddUser(user);
            if (b)
                msg = "Added successfully";
            else
                msg = "Failed to add user";
            return Redirect("/Content/Index");
            //return Page();
        }

    }
}
