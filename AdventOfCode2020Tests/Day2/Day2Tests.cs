using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
    [TestFixture]
    public class Day2Tests
    {
        [Test]
        public void SiteSample2020Part1()
        {
            Day2 day2 = new Day2();

            Assert.AreEqual("1", day2.GetPart1Result(new string[] { "1-3 a: abcde" }));
            Assert.AreEqual("0", day2.GetPart1Result(new string[] { "1-3 b: cdefg" }));
            Assert.AreEqual("1", day2.GetPart1Result(new string[] { "2-9 c: ccccccccc" }));
        }

        [Test]
        public void SiteSample2020Part2()
        {
            Day2 day2 = new Day2();

            Assert.AreEqual("1", day2.GetPart2Result(new string[] { "1-3 a: abcde" }));
            Assert.AreEqual("0", day2.GetPart2Result(new string[] { "1-3 b: cdefg" }));
            Assert.AreEqual("0", day2.GetPart2Result(new string[] { "2-9 c: ccccccccc" }));
        }
    }
}