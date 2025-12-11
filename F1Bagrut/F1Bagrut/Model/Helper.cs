using System.Data;
using Microsoft.Data.SqlClient;

namespace F1Bagrut.Model
{
    public class Helper
    {
        private string conString = "connection string";

        public Helper()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            conString = configuration.GetConnectionString("UserDB");
        }

        public DataTable RetrieveTable(string SQLStr, string table)
        // Gets A table from the data base acording to the SELECT Command in SQLStr;
        // Returns DataTable with the Table.
        {
            // connect to DataBase
            SqlConnection con = new SqlConnection(conString);

            // Build SQL Query
            SqlCommand cmd = new SqlCommand(SQLStr, con);

            // Build DataAdapter
            SqlDataAdapter ad = new SqlDataAdapter(cmd);

            // Build DataSet to store the data
            DataSet ds = new DataSet();

            // Get Data form DataBase into the DataSet
            ad.Fill(ds, table);

            return ds.Tables[table];
        }

        public int ExecuteNonQuery(string SQL)
        {
            SqlConnection con = new SqlConnection(conString); // התחברות למסד הנתונים

            SqlCommand cmd = new SqlCommand(SQL, con); // בניית פקודת SQL

            con.Open();
            int n = cmd.ExecuteNonQuery();   // ביצוע השאילתא
            con.Close();

            return n;     // return the number of rows affected
        }

        public int Delete(string id, string table)
        {
            //פעולה מקבלת את שם המשתמש ושם הטבלה
            if (id == string.Empty)
            {//בודקת שהמחרוזת של של שם המשתמש ריקה - עוצר את הפעולה ומחזיר -1
                return -1;
            }//מבצע שאילתת מחיקה ומפעיל פעולה 
            string SQL = $"DELETE FROM {table} WHERE userName = '{id}'";
            int n = ExecuteNonQuery(SQL);
            return n;
        }

        public int Update(User user, string table)
        {
            string SQL = $"UPDATE {table} " +
             $"SET userName = '{user.userName}', firstName = '{user.firstName}', " +
             $"lastName = '{user.lastName}', password = '{user.password}', " +
             $"email = '{user.email}', phoneNumber = '{user.phoneNumber}', " +
             $"gender = '{user.gender}', birthDay = '{user.birthDay}', " +
             $"city = '{user.city}', admin = '{user.admin}' " +
             $"WHERE userName = '{user.userName}'";
            int n = ExecuteNonQuery(SQL);
            return n;
        }


        public int Insert(User user, string table)
        // The Method recieve a user objects and insert it to the Database as new row. 
        // if the user is already taken the method will return -1.
        {
            // התחברות למסד הנתונים
            SqlConnection con = new SqlConnection(conString);

            // בניית פקודת SQL
            string SQLStr = $"SELECT * FROM {table} WHERE userName Like '{user.userName}'";
            SqlCommand cmd = new SqlCommand(SQLStr, con);

            // בניית DataSet
            DataSet ds = new DataSet();

            // טעינת סכימת הנתונים
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, table);

            if (ds.Tables[table].Rows.Count > 0)
            {
                return -1;
            }
            // בניית השורה להוספה
            DataRow dr = ds.Tables[table].NewRow();
            dr["userName"] = user.userName;
            dr["firstName"] = user.firstName;
            dr["lastName"] = user.lastName;
            dr["password"] = user.password;
            dr["email"] = user.email;
            dr["phoneNumber"] = user.phoneNumber;
            dr["gender"] = user.gender.ToString();
            dr["birthDay"] = user.birthDay.ToString();
            dr["city"] = user.city;
            dr["admin"] = user.admin;

            ds.Tables[table].Rows.Add(dr);

            // עדכון הדאטה סט בבסיס הנתונים
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            int n = adapter.Update(ds, table);
            return n;
        }

    }
}
