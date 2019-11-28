using AdventOfCodeCommon;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2015
{
    public class Day2 : IPuzzle
    {
        public string GetPart1Result(string[] input)
        {
            return GetWrappingPaperRequirements(input).Item1.ToString();
        }

        private Tuple<long, long> GetWrappingPaperRequirements(string[] input)
        {
            long neededPaper = 0;
            long neededRibbon = 0;
            Regex dimensionRegex = new Regex(@"(\d*)x(\d*)x(\d*)");

            foreach(string inputLine in input)
            {
                Match dimensionMatch = dimensionRegex.Match(inputLine);

                int.TryParse(dimensionMatch.Groups[1].Value, out int l);
                int.TryParse(dimensionMatch.Groups[2].Value, out int w);
                int.TryParse(dimensionMatch.Groups[3].Value, out int h);

                int[] list = { l, w, h };
                Array.Sort(list);

                neededRibbon += list[0] * 2 + list[1] * 2 + l * w * h;
                neededPaper += 2 * l * w + 2 * w * h + 2 * h * l + list[0] * list[1];
            }

            return new Tuple<long, long>(neededPaper, neededRibbon);
        }

        public string GetPart2Result(string[] input)
        {
            return GetWrappingPaperRequirements(input).Item2.ToString();
        }
    }
}
