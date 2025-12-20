using NUnit.Framework;

namespace AdventOfCode2025
{
    [TestFixture]
    public class Day2Tests
    {
        [Test]
        public void SampleInputsPart1()
        {
            Day2 day2 = new Day2();

            Assert.AreEqual("1227775554", day2.GetPart1Result([
                "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124"
            ]));
        }

        [Test]
        public void SampleInputsPart2()
        {
            Day2 day2 = new Day2();

            Assert.AreEqual("4174379265", day2.GetPart2Result([
                "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124"
            ]));
        }
    }
}
