using AdventOfCodeCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2015
{
    public class Day8 : IPuzzle
    {
        private struct LineStats
        {
            public int MemSize { get; set; }
            public int CodeSize { get; set; }
            public int EncodedSize { get; set; }
        }

        public string GetPart1Result(string[] inputList)
        {
            int memSize = 0;
            int codeSize = 0;

            foreach (string input in inputList)
            {
                memSize += CalculateMemSize(input);
                codeSize += input.Length;
            }

            return codeSize - memSize + "";
        }

        public int CalculateMemSize(string input)
        {
            int size = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '\\' && i < input.Length - 1)
                {
                    if (input[i + 1] == '"' || input[i + 1] == '\\') i++;
                    else if (input[i + 1] == 'x') i += 3;
                }

                size++;
            }
            return size - 2;
        }

        public int CalculateEncodedSize(string input)
        {
            return input.Replace(@"\", @"\\").Replace(@"""", @"\""").Length + 2;
        }

        public string GetPart2Result(string[] inputList)
        {
            int encodedSize = 0;
            int codeSize = 0;

            foreach (string input in inputList)
            {
                encodedSize += CalculateEncodedSize(input);
                codeSize += input.Length;
            }

            return encodedSize - codeSize + "";
        }
    }
}
