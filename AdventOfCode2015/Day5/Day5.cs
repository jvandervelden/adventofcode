using AdventOfCodeCommon;
using System;
using System.Collections.Generic;

namespace AdventOfCode2015
{
    public class Day5 : IPuzzle
    {
        public string GetPart1Result(string[] input)
        {
            return CountNiceStrings(input, false).ToString();
        }

        public int CountNiceStrings(string[] input, bool newNiceRequiremnets) {
            int niceStrings = 0;
            foreach (string inputString in input)
                niceStrings += (newNiceRequiremnets ? IsStringNicePart2(inputString) : IsStringNice(inputString)) ? 1 : 0;

            return niceStrings;
        }

        public bool IsStringNice(string input) {
            int vowelCount = 0;
            bool hasDoubles = false;
            bool hasBadString = false;

            for (int i = 0; i < input.Length; i++) {
                switch (input[i]) {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                        vowelCount++;
                        break;
                }

                if (i < input.Length - 1) {
                    if (input[i] == input[i + 1])
                        hasDoubles = true;

                    if ((input[i] == 'a' && input[i + 1] == 'b') || 
                        (input[i] == 'c' && input[i + 1] == 'd') ||
                        (input[i] == 'p' && input[i + 1] == 'q') ||
                        (input[i] == 'x' && input[i + 1] == 'y')) {
                        hasBadString = true;
                        break;
                    }
                }
            }

            return vowelCount >= 3 && hasDoubles && !hasBadString;
        }

        public bool IsStringNicePart2(string input) {
            bool hasRepeatingSeq = false;
            bool hasRepeatingChar = false;
            IDictionary<string, int> seenSequences = new Dictionary<string, int>();

            for (int i = 0; i < input.Length - 1; i++) {
                if (!hasRepeatingSeq) {
                    string currentSeq = input[i] + "" + input[i + 1];
                    if (seenSequences.ContainsKey(currentSeq) && seenSequences[currentSeq] != i - 1)
                        hasRepeatingSeq = true;
                    else if (!seenSequences.ContainsKey(currentSeq)) {
                        seenSequences.Add(currentSeq, i);
                    }
                }
                if (!hasRepeatingChar && i < input.Length - 2 && input[i] == input[i + 2])
                        hasRepeatingChar = true;

                if (hasRepeatingChar && hasRepeatingSeq)
                    break;
            }

            return hasRepeatingChar && hasRepeatingSeq;
        }

        public string GetPart2Result(string[] input)
        {
            return CountNiceStrings(input, true).ToString();
        }
    }
}
