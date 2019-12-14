using AdventOfCode2015;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019
{
    [TestFixture]
    public class Day5Tests
    {
        [Test]
        public void SiteSamplePart1()
        {
            Day5 day5 = new Day5();

            Assert.AreEqual("1", day5.GetPart1Result(new string[] { "ugknbfddgicrmopn" }));
            Assert.AreEqual("1", day5.GetPart1Result(new string[] { "aaa" }));
            Assert.AreEqual("0", day5.GetPart1Result(new string[] { "jchzalrnumimnmhp" }));
            Assert.AreEqual("0", day5.GetPart1Result(new string[] { "haegwjzuvuyypxyu" }));
            Assert.AreEqual("0", day5.GetPart1Result(new string[] { "dvszwmarrgswjxmb" }));
            Assert.AreEqual("0", day5.GetPart1Result(new string[] { "asdfabaaaa" }));
            Assert.AreEqual("0", day5.GetPart1Result(new string[] { "asdfcdaaaa" }));
            Assert.AreEqual("0", day5.GetPart1Result(new string[] { "asdfpqaaaa" }));
            Assert.AreEqual("0", day5.GetPart1Result(new string[] { "asdfxyaaaa" }));
        }

        [Test]
        public void SiteSamplePart2()
        {
            Day5 day5 = new Day5();

            Assert.AreEqual("1", day5.GetPart2Result(new string[] { "qjhvhtzxzqqjkmpb" }));
            Assert.AreEqual("1", day5.GetPart2Result(new string[] { "xxyxx" }));
            Assert.AreEqual("0", day5.GetPart2Result(new string[] { "uurcxstgmygtbstg" }));
            Assert.AreEqual("0", day5.GetPart2Result(new string[] { "ieodomkazucvgmuy" }));
        }
    }
}