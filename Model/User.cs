using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        private string username;
        private string pass;
        private int birthYear;
        private int tel;

        public string Username { get => username; set => username = value; }
        public string Pass { get => pass; set => pass = value; }
        public int BirthYear { get => birthYear; set => birthYear = value; }
        public int Tel { get => tel; set => tel = value; }
    }
    public class Dog
    {
        private string name;
        private int age;
        private string color;
        public string Name { get; set; }
        public int Age { get; set; }
        public string Color { get; set; }
    }

    public class Cat
    {
        private string name;
        private int age;
        private string color;
        public string Name { get; set; }
        public int Age { get; set; }
        public string Color { get; set; }
    }
}
