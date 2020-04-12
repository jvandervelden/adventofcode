using AdventOfCode2015;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2015
{
    [TestFixture]
    public class Day3Tests
    {
        [Test]
        public void SiteSamplePart1()
        {
            Day3 day3 = new Day3();

            Assert.AreEqual("2", day3.GetPart1Result(new string[] { ">" }));
            Assert.AreEqual("4", day3.GetPart1Result(new string[] { "^>v<" }));
            Assert.AreEqual("2", day3.GetPart1Result(new string[] { "^v^v^v^v^v" }));
        }

        [Test]
        public void SiteSamplePart2()
        {
            Day3 day3 = new Day3();

            Assert.AreEqual("3", day3.GetPart2Result(new string[] { "^v" }));
            Assert.AreEqual("3", day3.GetPart2Result(new string[] { "^>v<" }));
            Assert.AreEqual("11", day3.GetPart2Result(new string[] { "^v^v^v^v^v" }));
        }
    }
}