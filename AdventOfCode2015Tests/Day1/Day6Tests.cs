using AdventOfCode2015;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2015
{
    [TestFixture]
    public class Day6Tests
    {
        [Test]
        public void SiteSamplePart1()
        {
            Day6 day6 = new Day6();

            Assert.AreEqual("1000000", day6.GetPart1Result(new string[] { "turn on 0,0 through 999,999" }));
            Assert.AreEqual("999000", day6.GetPart1Result(new string[] { "turn on 0,0 through 999,999", "toggle 0,0 through 999,0" }));
            Assert.AreEqual("999996", day6.GetPart1Result(new string[] { "turn on 0,0 through 999,999", "turn off 499,499 through 500,500" }));
        }

        [Test]
        public void SiteSamplePart2()
        {
            Day6 day6 = new Day6();

            Assert.AreEqual("1000000", day6.GetPart1Result(new string[] { "turn on 0,0 through 999,999" }));
            Assert.AreEqual("2000000", day6.GetPart1Result(new string[] { "turn on 0,0 through 999,999", "turn on 0,0 through 999,999" }));
            Assert.AreEqual("1002000", day6.GetPart1Result(new string[] { "turn on 0,0 through 999,999", "toggle 0,0 through 999,0" }));
            Assert.AreEqual("999996", day6.GetPart1Result(new string[] { "turn on 0,0 through 999,999", "turn off 499,499 through 500,500" }));
        }
    }
}