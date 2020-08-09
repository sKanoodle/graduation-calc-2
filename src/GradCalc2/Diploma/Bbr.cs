using System;
using System.Collections.Generic;
using System.Text;

namespace GradCalc2.Diploma
{
    public class Bbr : Diploma
    {
        public override string Name => "Berufsbildungsreife";

        public Bbr(Student student) : base(student)
        {
        }

        protected override void Init(Grade[] grades)
        {
        }
    }
}
