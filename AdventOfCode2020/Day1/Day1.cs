using System;
using System.Collections.Generic;
using AdventOfCodeCommon;

namespace AdventOfCode2020
{
    public class Day1 : IPuzzle
    {
        public string GetPart1Result(string[] input)
        {
            ISet<int> numbers = BuildNumberHash(input);

            if (FindNumbersThatAdd(2020, numbers, out int lhs, out int rhs))
                return $"{lhs * rhs}";

            throw new PuzzleException("Unable to find 2 numbers that add to 2020");
        }

        public bool FindNumbersThatAdd(int sum, ISet<int> numbers, out int num1, out int num2)
        {
            num1 = 0;
            num2 = 0;

            foreach (int number in numbers)
            {
                int opposite = sum - number;
                if (numbers.Contains(opposite))
                {
                    num1 = number;
                    num2 = opposite;
                    return true;
                }
            }

            return false;
        }

        public ISet<int> BuildNumberHash(string[] inputs)
        {
            ISet<int> numbers = new HashSet<int>();

            foreach (string input in inputs)
            {
                if (int.TryParse(input, out int parsedInput))
                {
                    numbers.Add(parsedInput);
                }
            }

            return numbers;
        }

        public string GetPart2Result(string[] input)
        {
            ISet<int> numbers = BuildNumberHash(input);

            foreach (int number in numbers)
            {
                if (FindNumbersThatAdd(2020 - number, numbers, out int lhs, out int rhs))
                    return $"{lhs * rhs * number}";
            }

            throw new PuzzleException("Unable to find 2 numbers that add to 2020");
        }
    }
}