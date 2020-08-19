using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradCalc2.Views.SinglePageApplication
{
    public class SubjectRenderSettings
    {
        public List<SubjectRenderSetting> Subjects { get; } = new List<SubjectRenderSetting>();

        public class SubjectRenderSetting
        {
            public Subject Subject { get; }
            public bool CanBeAdvancedCourse { get; }

            public SubjectRenderSetting(Subject subject, bool canBeAdvancedCourse)
            {
                Subject = subject;
                CanBeAdvancedCourse = canBeAdvancedCourse;
            }
        }
    }
}
