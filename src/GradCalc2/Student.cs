using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradCalc2
{
    public class Student
    {
        public string FirstName { get; }
        public string LastName { get; }
        private readonly Grade[] _Grades;
        public IEnumerable<Grade> Grades => _Grades;

        public Student(string firstName, string lastName, Grade[] grades)
        {
            FirstName = firstName;
            LastName = lastName;
            _Grades = grades;
        }

        public Grade this[Subject subject] => Grades.FirstOrDefault(g => g.Subject == subject);

        public Student WithGrade(Grade grade)
        {
            var result = new Student(FirstName, LastName, _Grades);
            for (int i = 0; i < result._Grades.Length; i++)
                if (_Grades[i].Subject == grade.Subject)
                    _Grades[i] = grade;
            return result;
        }
    }
}
