using NUnit.Framework;

namespace AdventOfCode2025
{
    [TestFixture]
    public class Day4Tests
    {
        [Test]
        public void SampleInputsPart1()
        {
            Day4 daySolution = new Day4();

            Assert.AreEqual("13", daySolution.GetPart1Result([
                "..@@.@@@@.",
                "@@@.@.@.@@",
                "@@@@@.@.@@",
                "@.@@@@..@.",
                "@@.@@@@.@@",
                ".@@@@@@@.@",
                ".@.@.@.@@@",
                "@.@@@.@@@@",
                ".@@@@@@@@.",
                "@.@.@@@.@."
            ]));
        }

        [Test]
        public void SampleInputsPart2()
        {
            Day4 daySolution = new Day4();

            Assert.AreEqual("43", daySolution.GetPart2Result([
                "..@@.@@@@.",
                "@@@.@.@.@@",
                "@@@@@.@.@@",
                "@.@@@@..@.",
                "@@.@@@@.@@",
                ".@@@@@@@.@",
                ".@.@.@.@@@",
                "@.@@@.@@@@",
                ".@@@@@@@@.",
                "@.@.@@@.@."
            ]));
        }
    }
}
