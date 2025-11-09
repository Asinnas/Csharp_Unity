using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B1
{
    class Person
    {
        private string fullName;
        private int age;
        private string locate;
        public Person() { }
        public Person(string fullName, int age, string locate)
        {
            this.fullName = fullName;
            this.age = age;
            this.locate = locate;
        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value > 0)
                {
                    age = value;
                }
                else
                {
                    throw new ArgumentException("Age must be positive.");
                }
            }
        }

        public string Locate
        {
            get { return locate; }
            set { locate = value; }
        }

    }
}
