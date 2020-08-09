using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradCalc2.Diploma
{
    public abstract class Diploma
    {
        public List<string> ReasonsForFailing { get; } = new List<string>();
        public List<string> Info { get; } = new List<string>();
        public List<string> Advice { get; } = new List<string>();
        public bool IsAttained { get; protected set; } = true;
        public abstract string Name { get; }

        public Diploma(Student student)
        {
            Init(student.Grades.ToArray());
        }

        protected abstract void Init(Grade[] grades);

        protected void Fail(string reason)
        {
            ReasonsForFailing.Add(reason);
            IsAttained = false;
        }
    }
}
