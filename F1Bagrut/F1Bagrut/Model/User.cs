using System.Data;
using Microsoft.Data.SqlClient;

namespace F1Bagrut.Model
{
    public class User
    {
        public string userName { get; set; } = string.Empty;
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public string password{ get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string phoneNumber { get; set; } = string.Empty;
        public string gender{ get; set; } = string.Empty;
        public int birthDay{ get; set; }
        public string city{ get; set; } = string.Empty;
        public bool admin{ get; set; }
    }
}
