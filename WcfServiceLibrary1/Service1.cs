using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml.Linq;
using ViewDB;
using Model;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public bool AddUser(User user)
        {
            UsersDB u = new UsersDB();
            bool res = u.AddUser(user);
            return res;
        }

        public int CheckUser(UserLogin user)
        {
            UsersDB u = new UsersDB();
            int res = u.CheckUser(user);
            return res;
        }
        public bool AddDog(Dog dog)
        {
            AnimalsDB db = new AnimalsDB();
            return db.AddDog(dog);
        }

        public bool AddCat(Cat cat)
        {
            AnimalsDB db = new AnimalsDB();
            return db.AddCat(cat);
        }
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public PizzaMenu CheckPizzaOrder(PizzaMenu order) 
        {
            if  (order.Name=="Linor")
            {
                order.Price= 0;
            }
            return order;
        }


    }
}
