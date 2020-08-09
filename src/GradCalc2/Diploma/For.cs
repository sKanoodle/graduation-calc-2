using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace GradCalc2.Diploma
{
    public class For : Diploma
    {
        public override string Name => "Fachoberschulreife";

        protected virtual int MinBCoursesCount => 2;
        protected virtual int MaxBCourseGrade => 4;
        protected virtual int MaxACourseGrade => 3;
        protected virtual int MinOtherSubjectCount => 2;
        protected virtual int MaxGradeForNOtherSubjects => 3;
        protected virtual int MaxAverageGradeOtherSubjects => 4;
        protected virtual int MaxCountOf6sInOtherSubjects => 0;
        protected virtual int MaxCountOf5sInOtherSubjects => 2;

        protected virtual int CompensationMaxACourseGrade => 2;
        protected virtual int CompensationMaxBCourseGrade => 3;
        protected virtual int CompensationMaxWP1Grade => 3;

        public For(Student student) : base(student)
        {
        }

        protected override void Init(Grade[] grades)
        {
            var bCourses = grades.Where(g => g.Course == AdvancedCourseDifferentiation.B).ToArray();
            if (bCourses.Length < MinBCoursesCount)
                Fail($"Nicht genug B-Kurse ({bCourses.Length}/{MinBCoursesCount})");
            foreach (var bCourse in bCourses.Where(g => g.Value > MaxBCourseGrade))
                GetCompensation(bCourse, grades);

            var aCourses = grades.Where(g => g.Course == AdvancedCourseDifferentiation.A).ToArray();
            foreach (var aCourse in aCourses.Where(g => g.Value > MaxACourseGrade))
                GetCompensation(aCourse, grades);

            var restCourses = grades.Where(g => g.Course == AdvancedCourseDifferentiation.None).ToArray();
            if (restCourses.Count(g => g.Value <= MaxGradeForNOtherSubjects) < MinOtherSubjectCount)
                Fail($"nicht mindestens {MinOtherSubjectCount} {MaxGradeForNOtherSubjects}en in restlichen Fächern erreicht");

            var countOf6s = restCourses.Count(g => g.Value == 6);
            if (countOf6s > MaxCountOf6sInOtherSubjects)
                Fail($"zu viele 6en ({countOf6s}/{MaxCountOf6sInOtherSubjects})");

            var countOf5s = restCourses.Count(g => g.Value == 5);
            if (countOf5s > MaxCountOf5sInOtherSubjects)
                Fail($"zu viele 5en ({countOf5s}/{MaxCountOf5sInOtherSubjects})");

            var restAverage = restCourses.Length == 0 ? 0 : restCourses.Average(g => (decimal)g.Value);
            restAverage = (int)(restAverage * 10) / (decimal)10; // ignore everything after second decimal
            if (restAverage > MaxAverageGradeOtherSubjects)
                Fail($"Durchschnitt der restlichen Noten zu schlecht ({restAverage}/{MaxAverageGradeOtherSubjects})");
        }

        private readonly List<Grade> UsedForCompensation = new List<Grade>();
        private int RemainingCompensations = 1;

        private Grade GetCompensation(Grade fail, Grade[] grades)
        {
            var text = $"{fail.Value} im {fail.Course}-Kurs {fail.Subject.T()}";
            var failText = $"{text} kann nicht ausgeglichen werden";
            var compText = $"{text} wurde ausgeglichen mit";
            var maxGrade = fail.Course switch
            {
                AdvancedCourseDifferentiation.B => MaxBCourseGrade,
                AdvancedCourseDifferentiation.A => MaxACourseGrade,
                _ => throw new NotImplementedException(),
            };

            if (RemainingCompensations-- < 1)
            {
                Fail($"{failText}, Anzahl der maximalen Ausgleiche erreicht");
                return default;
            }

            if (fail.Value > maxGrade + 1)
            {
                Fail($"{failText}, maximal eine {maxGrade + 1} kann ausgeglichen werden");
                return default;
            }

            Grade successfulCompensation = default;
            foreach (var compensation in grades.Except(UsedForCompensation))
            {
                if (compensation.Course == AdvancedCourseDifferentiation.A && compensation.Value <= CompensationMaxACourseGrade)
                {
                    Info.Add($"{compText} {compensation.Value} im A-Kurs {compensation.Subject.T()}");
                    successfulCompensation = compensation;
                }
                else if (compensation.Course == AdvancedCourseDifferentiation.B && compensation.Value <= CompensationMaxBCourseGrade)
                {
                    Info.Add($"{compText} {compensation.Value} im B-Kurs {compensation.Subject.T()}");
                    successfulCompensation = compensation;
                }
                else if (compensation.Subject == Subject.WP1 && compensation.Value <= CompensationMaxWP1Grade)
                {
                    Info.Add($"{compText} {compensation.Value} in {compensation.Subject.T()}");
                    successfulCompensation = compensation;
                }
                else
                    continue;
                break;
            }

            if (successfulCompensation == default)
                Fail($"{failText}, es wurde kein möglicher Ausgleich gefunden");
            else
                UsedForCompensation.Add(successfulCompensation);
            return successfulCompensation;
        }
    }
}
