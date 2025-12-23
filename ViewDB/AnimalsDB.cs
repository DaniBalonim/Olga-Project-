using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewDB
{
    public class AnimalsDB : BaseDB
    {
        public bool AddDog(Dog dog)
        {
            string sql = $"INSERT INTO Dogs ([Name], [Age], [Color]) VALUES ('{dog.Name}', {dog.Age}, '{dog.Color}');";

            int records = SaveChanges(sql);

            if (records < 1)
                return false;
            return true;
        }

        public bool AddCat(Cat cat)
        {
            string sql = $"INSERT INTO Cats ([Name], [Age], [Color]) VALUES ('{cat.Name}', {cat.Age}, '{cat.Color}');";

            int records = SaveChanges(sql);

            if (records < 1)
                return false;
            return true;
        }
    }
}