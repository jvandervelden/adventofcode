using AdventOfCode2015;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2015
{
    [TestFixture]
    public class Day4Tests
    {
        [Test]
        public void SiteSamplePart1()
        {
            Day4 day4 = new Day4();

            Assert.AreEqual("609043", day4.GetPart1Result(new string[] { "abcdef" }));
            Assert.AreEqual("1048970", day4.GetPart1Result(new string[] { "pqrstuv" }));
        }

        [Test]
        public void SiteSamplePart2()
        {
            Day4 day4 = new Day4();

            Assert.AreEqual("6742839", day4.GetPart2Result(new string[] { "abcdef" }));
            Assert.AreEqual("5714438", day4.GetPart2Result(new string[] { "pqrstuv" }));
        }
    }
}