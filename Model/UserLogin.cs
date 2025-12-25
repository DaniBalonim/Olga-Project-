using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserLogin
    {
        private string username;
        private string pass;

        public string Username { get => username; set => username = value; }
        public string Pass { get => pass; set => pass = value; }
    }
}
