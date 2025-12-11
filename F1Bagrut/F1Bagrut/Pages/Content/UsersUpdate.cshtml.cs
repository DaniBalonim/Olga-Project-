using F1Bagrut.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace F1Bagrut.Pages.Content
{
    public class UsersUpdateModel : PageModel
    {
        [BindProperty]
        public User NewUser { get; set; } = new User();
        public  string msg { get; set; } = string.Empty;

        public IActionResult OnGet(string param)
        {
            string user = param;
            Helper helper = new Helper();
            string SQL = $"SELECT * FROM usersTB WHERE userName = '{param}'";
            DataTable dt = helper.RetrieveTable(SQL, "usersTB");
            DataRow dr = dt.Rows[0];
            NewUser.userName = dr["userName"].ToString();
            NewUser.firstName = dr["firstName"].ToString();
            NewUser.lastName = dr["lastName"].ToString();
            NewUser.password = dr["password"].ToString();
            NewUser.email = dr["email"].ToString();
            NewUser.phoneNumber = dr["phoneNumber"].ToString();
            NewUser.gender = dr["gender"].ToString();
            NewUser.birthDay = DateTime.Parse(dr["birthDay"].ToString());
            NewUser.city = dr["city"].ToString();
            NewUser.admin = (bool)dr["admin"];
            return Page();
        }
        public IActionResult OnPost()
        {
            Helper helper = new Helper();
            try
            {
                int n = helper.Update(NewUser, "usersTB");
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return Page();
            }
            return RedirectToPage("Index");
        }


    }
}
