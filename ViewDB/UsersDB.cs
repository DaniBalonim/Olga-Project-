using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewDB
{
    public class UsersDB : BaseDB
    {
        public bool AddUser(User user)
        {
            string mySQL = $"INSERT INTO Users ([username], pass, birthYear, tel) VALUES ('{user.Username}', '{user.Pass}', {user.BirthYear}, {user.Tel});";

            int records = SaveChanges(mySQL);
            //return list;
            if (records < 1)
                return false;
            return true;
        }

        public int CheckUser(UserLogin user)
        {
            //string mySQL = $"SELECT COUNT(*) FROM Users WHERE username='{user.Username}';";
            //int count = SaveChanges(mySQL);
            //if(count < 1)
            //    return 0;
            return 1;
        }
    }
}
