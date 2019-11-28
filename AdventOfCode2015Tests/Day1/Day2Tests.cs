using AdventOfCode2015;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019
{
    [TestFixture]
    public class Day2Tests
    {
        [Test]
        public void SiteSamplePart1()
        {
            Day2 day2 = new Day2();

            Assert.AreEqual("58", day2.GetPart1Result(new string[] { "2x3x4" }));
            Assert.AreEqual("43", day2.GetPart1Result(new string[] { "1x1x10" }));
            Assert.AreEqual("101", day2.GetPart1Result(new string[] { "1x1x10", "2x3x4" }));
        }

        [Test]
        public void SiteSamplePart2()
        {
            Day2 day2 = new Day2();

            Assert.AreEqual("34", day2.GetPart2Result(new string[] { "2x3x4" }));
            Assert.AreEqual("14", day2.GetPart2Result(new string[] { "1x1x10" }));
            Assert.AreEqual("48", day2.GetPart2Result(new string[] { "1x1x10", "2x3x4" }));
        }
    }
}