using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradCalc2
{
    public class Grade
    {
        private static readonly Subject[] SubjectGroup1 = new[] { Subject.German, Subject.Mathematics, Subject.English, Subject.WP1 };

        public Subject Subject { get; }
        public AdvancedCourseDifferentiation Course { get; }
        public int Value { get; }
        public bool IsSubjectGroup1 => SubjectGroup1.Contains(Subject);

        public Grade(Subject subject, AdvancedCourseDifferentiation course, int value)
        {
            Subject = subject;
            Course = course;
            Value = value;
        }

        public Grade WithLowerCourse()
        {
            if (Course == AdvancedCourseDifferentiation.B)
                return new Grade(Subject, AdvancedCourseDifferentiation.A, Math.Max(1, Value - 1));
            return this;
        }

        public Grade WithValue( int value )
        {
            return new Grade(Subject, Course, value);
        }

        public Grade WithCourse(AdvancedCourseDifferentiation course)
        {
            return new Grade(Subject, course, Value);
        }
    }
}
