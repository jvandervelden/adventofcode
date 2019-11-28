using AdventOfCodeCommon;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace AdventOfCode2015
{
    public class Day4 : IPuzzle
    {
        public string GetPart1Result(string[] input)
        {
            return FindHashIndexWithFiveZeros(input[0], 0xF0).ToString();
        }

        public uint FindHashIndexWithFiveZeros(string input, byte byte3Mask)
        {
            MD5 mD5 = MD5.Create();
            uint index = 0;

            while(index < 0xFFFFFFFF)
            {
                byte[] hash = CalculateHash(mD5, input, index);

                if (hash[0] == 0 &&
                    hash[1] == 0 &&
                    (hash[2] & byte3Mask) == 0)
                    break;

                index++;
            }

            return index;
        }

        public byte[] CalculateHash(MD5 mD5, string input, uint index)
        {
            byte[] hashInput = Encoding.ASCII.GetBytes(input + index.ToString());

            return mD5.ComputeHash(hashInput);
        }

        public string GetPart2Result(string[] input)
        {
            return FindHashIndexWithFiveZeros(input[0], 0xFF).ToString();
        }
    }
}
