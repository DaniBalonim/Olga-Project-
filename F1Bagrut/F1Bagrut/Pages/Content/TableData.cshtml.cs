using F1Bagrut.Model;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace F1Bagrut.Pages.Content
{
    public class TableDataModel : PageModel
    {
        public DataTable dT { get; set; }
        [BindProperty]
        public string filter { get; set; } = string.Empty;
        [BindProperty]
        public string column { get; set; }
        [BindProperty]
        public string order { get; set; }
        [BindProperty]
        public string userName1 { get; set; } = string.Empty;


        public IActionResult OnGet()
        {
            if(HttpContext.Session.GetString("Admin")!="True")
            {
                return Redirect("/Content/AccessDenied");
            }
            Helper helper = new Helper();
            string sql = "SELECT * FROM usersTB";
            dT = helper.RetrieveTable(sql, "usersTB");
            return Page();
        }

        public IActionResult OnPostSort()
        {
            Helper helper = new Helper();
            string SQL = $"SELECT * FROM usersTB ORDER BY {column} {order}";
            dT = helper.RetrieveTable(SQL, "UsersTB");
            return Page();
        }

        public IActionResult OnPostFilter()
        {
            Helper helper = new Helper();
            string SQL = "SELECT * FROM usersTB";
            if (filter != string.Empty)
            {
                SQL = $"SELECT * FROM usersTB WHERE firstName LIKE '%{filter}%' OR lastName LIKE '%{filter}%' OR birthDay LIKE '%{filter}%'";
            }
            dT = helper.RetrieveTable(SQL, "UsersTB");
            return Page();
        }

        public IActionResult OnPostDelete()
        {
            Helper helper = new Helper();
            helper.Delete(userName1, "UsersTB");
            string SQL = "SELECT * FROM UsersTB";
            dT = helper.RetrieveTable(SQL, "UsersTB");
            return Page();
        }
    }
}
