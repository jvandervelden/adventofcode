using System;
using System.Text.RegularExpressions;
using AdventOfCodeCommon;

namespace AdventOfCode2020
{
    public class Day2 : IPuzzle
    {
        private static Regex _policyRegex = new Regex(@"^(\d+)-(\d+) ([a-z]): (.+)$");
        private struct Policy
        {
            public int max;
            public int min;
            public char character;
            public string password;

            public static Policy Parse(string policy) 
            {
                Match match = _policyRegex.Match(policy);

                if (!match.Success) {
                    throw new PuzzleException($"Unable to parse policy {policy}");
                }

                return new Policy {
                    min = int.Parse(match.Groups[1].Value),
                    max = int.Parse(match.Groups[2].Value),
                    character = match.Groups[3].Value[0],
                    password = match.Groups[4].Value
                };
            }

            public bool IsValidPolicy1() {
                int charCount = 0;
                foreach (char strChar in password)
                    if (strChar == character)
                        charCount++;
                return charCount >= min && charCount <= max;
            }

            public bool IsValidPolicy2() {
                bool pos1Match = password.Length >= min ? password[min - 1] == character : false;
                bool pos2Match = password.Length >= max ? password[max - 1] == character : false;
                
                return (pos1Match || pos2Match) && pos1Match ^ pos2Match;
            }
        }

        public string GetPart1Result(string[] inputs)
        {
            int validPasswords = 0;

            foreach (string input in inputs) {
                if (Policy.Parse(input).IsValidPolicy1()) {
                    validPasswords++;
                }
            }

            return $"{validPasswords}";
        }

        public string GetPart2Result(string[] inputs)
        {
            int validPasswords = 0;

            foreach (string input in inputs) {
                if (Policy.Parse(input).IsValidPolicy2()) {
                    validPasswords++;
                }
            }

            return $"{validPasswords}";
        }
    }
}