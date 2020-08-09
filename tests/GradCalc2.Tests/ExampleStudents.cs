using System;
using System.Collections.Generic;
using System.Text;

namespace GradCalc2.Tests
{
    static class ExampleStudents
    {
        public static Student BarbaraMeyer => new Student("Barbara", "Meyer", new[] {
            new Grade(Subject.Mathematics, AdvancedCourseDifferentiation.A, 6),
            new Grade(Subject.German, AdvancedCourseDifferentiation.A, 6),
        });
    }
}
