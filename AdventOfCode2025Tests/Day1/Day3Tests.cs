using NUnit.Framework;

namespace AdventOfCode2025
{
    [TestFixture]
    public class Day3Tests
    {
        [Test]
        public void SampleInputsPart1()
        {
            Day3 daySolution = new Day3();

            Assert.AreEqual("357", daySolution.GetPart1Result([
                "987654321111111",
                "811111111111119",
                "234234234234278",
                "818181911112111"
            ]));
        }

        [Test]
        public void SampleInputsPart2()
        {
            Day3 daySolution = new Day3();

            Assert.AreEqual("3121910778619", daySolution.GetPart2Result([
                "987654321111111",
                "811111111111119",
                "234234234234278",
                "818181911112111"
            ]));
        }
    }
}
