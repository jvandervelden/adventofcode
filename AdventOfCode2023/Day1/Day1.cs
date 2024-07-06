using System.Text.RegularExpressions;
using AdventOfCodeCommon;

namespace AdventOfCode2023;

public class Day1 : IPuzzle
{
    public string GetPart1Result(string[] inputs)
    {
        return parseInput(inputs, @"(\d)");
    }

    public string GetPart2Result(string[] inputs)
    {
        return parseInput(inputs, @"(one|two|three|four|five|six|seven|eight|nine|\d)");
    }

    private string parseInput(string[] inputs, string regex) {
        long runningTotal = 0;
        foreach (string input in inputs) {
            Match numbers = Regex.Match(input, regex);
            List<string> parsedNumbers = new List<string>();

            while (numbers.Captures.Count > 0) {
                parsedNumbers.Add(toNumber(numbers.Captures.First().Value));
                numbers = numbers.NextMatch();
            }

            string inputNumber = parsedNumbers.First() + parsedNumbers.Last();

            runningTotal += int.Parse(inputNumber);
        }

        return runningTotal + "";
    }

    private string toNumber(string inNumber) {
        switch (inNumber) {
            case "one":
              return "1";
            case "two":
              return "2";
            case "three":
              return "3";
            case "four":
              return "4";
            case "five":
              return "5";
            case "six":
              return "6";
            case "seven":
              return "7";
            case "eight":
              return "8";
            case "nine":
              return "9";
            default:
              return inNumber;
        }
    }
}
