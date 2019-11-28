using AdventOfCodeCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2015
{
    public class Day1 : IPuzzle
    {
        public string GetPart1Result(string[] input)
        {
            return ProcessInput(input[0], false).ToString();
        }

        public int ProcessInput(string input, bool firstBasementChar)
        {
            int output = 0;

            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '(': output++; break;
                    case ')': output--; break;
                };

                if (output == -1 && firstBasementChar)
                {
                    output = i;
                    break;
                }
            }

            return output;
        }

        public string GetPart2Result(string[] input)
        {
            // Answer is 1 indexed so add 1
            return (ProcessInput(input[0], true) + 1).ToString();
        }
    }
}
