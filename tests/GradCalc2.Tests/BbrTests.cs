using GradCalc2.Diploma;
using System;
using Xunit;

namespace GradCalc2.Tests
{
    public class BbrTests
    {
        [Fact]
        public void AlwaysAttained()
        {
            var student = ExampleStudents.BarbaraMeyer;
            var bbr = new Bbr(student);
            Assert.True(bbr.IsAttained);
            Assert.Empty(bbr.ReasonsForFailing);
        }
    }
}
