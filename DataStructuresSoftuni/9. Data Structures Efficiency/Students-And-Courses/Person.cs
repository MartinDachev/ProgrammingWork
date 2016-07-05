using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_And_Courses
{
    public class Person : IComparable<Person>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int CompareTo(Person other)
        {
            int comparisonResult = this.LastName.CompareTo(other.LastName);

            if (comparisonResult == 0)
            {
                comparisonResult = this.FirstName.CompareTo(other.FirstName);
            }

            return comparisonResult;
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
