using System;
using System.Collections.Generic;
using System.Text;

namespace GradCalc2
{
    public class Student
    {
        public string FirstName { get; }
        public string LastName { get; }
        public Grade[] Grades { get; }

        public Student(string firstName, string lastName, Grade[] grades)
        {
            FirstName = firstName;
            LastName = lastName;
            Grades = grades;
        }
    }
}
