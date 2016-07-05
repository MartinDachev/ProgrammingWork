using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_And_Courses
{
    class StudentsAndCourses
    {
        static SortedDictionary<string, SortedSet<Person>> personsByCourse = new SortedDictionary<string, SortedSet<Person>>();

        static void Main(string[] args)
        {
            StreamReader file = new StreamReader("students.txt");
            string line;
            char[] separators = { '|' };

            while ((line = file.ReadLine()) != null)
            {
                var tokens = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                var firstName = tokens[0].Trim();
                var lastName = tokens[1].Trim();
                var courseName = tokens[2].Trim();
                var person = new Person(firstName, lastName);
                personsByCourse.AppendValueToKey(courseName, person);
            }

            foreach (var course in personsByCourse)
            {
                Console.WriteLine("{0}: {1}", course.Key, string.Join(", ", course.Value));
            }
        }
    }
}
