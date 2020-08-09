using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradCalc2.Diploma
{
    public class Ebr : Diploma
    {
        public override string Name => "erweiterte Berufsbildungsreife";

        public Ebr(Student student) : base(student)
        {
        }

        protected override void Init(Grade[] grades)
        {
            ConvertCourses(grades);

            var failures = grades.Where(g => g.Value > 4).ToArray();
            foreach (var grade in grades.Where(g => g.Value == 6))
                Fail($"6 in {grade.Subject.T()}");
            if (failures.Length > 2)
                Fail("mehr als 2 Ausfälle");
            if (failures.Any(g => g.Subject == Subject.German) && failures.Any(g => g.Subject == Subject.Mathematics))
                Fail($"Ausfälle in {Subject.German.T()} UND {Subject.Mathematics.T()}");
            List<Grade> alreadyUsed = new List<Grade>();
            foreach (var toCompensate in failures)
            {
                Grade compensation = grades
                    .Except(alreadyUsed)
                    .FirstOrDefault(g => g.Value <= 3 && g.IsSubjectGroup1 == toCompensate.IsSubjectGroup1);
                if (compensation == default)
                    Fail($"Ausfall ({toCompensate.Value}) in {toCompensate.Subject.T()} kann nicht ausgeglichen werden");
                else
                {
                    Info.Add($"Ausfall ({toCompensate.Value}) in {toCompensate.Subject.T()} mit {compensation.Value} in {compensation.Subject.T()} ausgeglichen");
                    alreadyUsed.Add(compensation);
                }
            }
        }

        private void ConvertCourses(Grade[] grades)
        {
            for (int i = 0; i < grades.Length; i++)
            {
                var grade = grades[i];
                var lowerCourseGrade = grade.WithLowerCourse();
                if (grade != lowerCourseGrade)
                    Info.Add($"A-Kurs {grade.Subject.T()} zu B-Kurs umgewandelt ({grade.Value} -> {lowerCourseGrade.Value})");
                grades[i] = lowerCourseGrade;
            }
        }
    }
}
