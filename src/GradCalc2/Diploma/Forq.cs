using System;
using System.Collections.Generic;
using System.Text;

namespace GradCalc2.Diploma
{
    public class Forq : For
    {
        public override string Name => "Fachoberschulreife Gym";

        protected override int MinBCoursesCount => 3;
        protected override int MaxBCourseGrade => 3;
        protected override int MaxACourseGrade => 2;
        protected override int MaxGradeForNOtherSubjects => 2;
        protected override int MaxAverageGradeOtherSubjects => 3;
        protected override int MaxCountOf5sInOtherSubjects => 1;

        protected override int CompensationMaxACourseGrade => 1;
        protected override int CompensationMaxBCourseGrade => 2;
        protected override int CompensationMaxWP1Grade => 2;

        public Forq(Student student) : base(student)
        {
        }
    }
}
