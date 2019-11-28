using AdventOfCode2015;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019
{
    [TestFixture]
    public class Day1Tests
    {
        [Test]
        public void SiteSamplePart1()
        {
            Day1 day1 = new Day1();

            Assert.AreEqual("0", day1.GetPart1Result(new string[] { "(())" }));
            Assert.AreEqual("3", day1.GetPart1Result(new string[] { "(()(()(" }));
            Assert.AreEqual("3", day1.GetPart1Result(new string[] { "))(((((" }));
            Assert.AreEqual("-1", day1.GetPart1Result(new string[] { "())" }));
            Assert.AreEqual("-3", day1.GetPart1Result(new string[] { ")())())" }));
        }

        [Test]
        public void SiteSamplePart2()
        {
            Day1 day1 = new Day1();

            Assert.AreEqual("1", day1.GetPart2Result(new string[] { ")" }));
            Assert.AreEqual("5", day1.GetPart2Result(new string[] { "()())" }));
        }
    }
}