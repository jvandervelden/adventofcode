using AdventOfCodeCommon;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2015
{
    public class Day3 : IPuzzle
    {
        public string GetPart1Result(string[] input)
        {
            return GetHouseInformation(input[0], 1).ToString();
        }

        public int GetHouseInformation(string input, int numberOfSantas)
        {
            ISet<string> visitedLocations = new HashSet<string>();
            int[] xLocations = new int[numberOfSantas];
            int[] yLocations = new int[numberOfSantas];

            visitedLocations.Add("0,0");

            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '^': yLocations[i % numberOfSantas]++; break;
                    case 'v': yLocations[i % numberOfSantas]--; break;
                    case '<': xLocations[i % numberOfSantas]--; break;
                    case '>': xLocations[i % numberOfSantas]++; break;
                }

                string key = $"{xLocations[i % numberOfSantas]},{yLocations[i % numberOfSantas]}";

                if (!visitedLocations.Contains(key))
                    visitedLocations.Add(key);
            }

            return visitedLocations.Count;
        }

        public string GetPart2Result(string[] input)
        {
            return GetHouseInformation(input[0], 2).ToString();
        }
    }
}
