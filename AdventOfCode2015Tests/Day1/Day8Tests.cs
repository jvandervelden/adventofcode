using AdventOfCode2015;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2015
{
    [TestFixture]
    public class Day8Tests
    {
        [Test]
        public void SiteSamplePart1()
        {
            Day8 day8 = new Day8();

            Assert.AreEqual("2", day8.GetPart1Result(new string[] { "\"\"" }));
            Assert.AreEqual("2", day8.GetPart1Result(new string[] { "\"abc\"" }));
            Assert.AreEqual("3", day8.GetPart1Result(new string[] { "\"aaa\\\"aaa\"" }));
            Assert.AreEqual("5", day8.GetPart1Result(new string[] { "\"\\x27\"" }));
            Assert.AreEqual("12", day8.GetPart1Result(new string[] { @"""""", @"""abc""", @"""aaa\""aaa""", @"""\x27""" }));
        }

        [Test]
        public void SiteSamplePart2()
        {
            Day8 day8 = new Day8();

            Assert.AreEqual("4", day8.GetPart2Result(new string[] { "\"\"" }));
            Assert.AreEqual("4", day8.GetPart2Result(new string[] { "\"abc\"" }));
            Assert.AreEqual("6", day8.GetPart2Result(new string[] { "\"aaa\\\"aaa\"" }));
            Assert.AreEqual("5", day8.GetPart2Result(new string[] { "\"\\x27\"" }));
            Assert.AreEqual("19", day8.GetPart2Result(new string[] { @"""""", @"""abc""", @"""aaa\""aaa""", @"""\x27""" }));
        }
    }
}