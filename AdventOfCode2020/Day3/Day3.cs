using AdventOfCodeCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
    public class Day3 : IPuzzle
    {
        public string GetPart1Result(string[] input)
        {
            return $"{CountTreeHit(input, 3, 1)}";
        }

        public int CountTreeHit(string[] landscape, int right, int down)
        {
            int currentIndex = 0;
            int treeHit = 0;

            for (int i = down; i < landscape.Length; i += down)
            {
                currentIndex += right;
                if (currentIndex > landscape[i].Length - 1)
                    currentIndex -= landscape[i].Length;
                if (landscape[i][currentIndex] == '#')
                    treeHit++;
            }

            return treeHit;
        }

        public string GetPart2Result(string[] input)
        {
            int angle1 = CountTreeHit(input, 1, 1);
            int angle2 = CountTreeHit(input, 3, 1);
            int angle3 = CountTreeHit(input, 5, 1);
            int angle4 = CountTreeHit(input, 7, 1);
            int angle5 = CountTreeHit(input, 1, 2);
            long angleProduct = (long)angle1 * angle2 * angle3 * angle4 * angle5;

            return $"{angleProduct}";
        }
    }
}
