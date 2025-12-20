using NUnit.Framework;

namespace AdventOfCode2025
{
    [TestFixture]
    public class Day1Tests
    {
        [Test]
        public void SampleInputsPart1()
        {
            Day1 day1 = new Day1();

            Assert.AreEqual("3", day1.GetPart1Result([
                "L500", "R500", "L68","L30","R48","L5","R60","L55","L1","L99","R14","L82"
            ]));
        }

        [Test]
        public void SampleInputsPart2()
        {
            Day1 day1 = new Day1();

            Assert.AreEqual("16", day1.GetPart2Result([
                "L500", "R500", "L68","L30","R48","L5","R60","L55","L1","L99","R14","L82"
            ]));
        }
    }
}
