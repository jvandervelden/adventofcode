using System.Text.RegularExpressions;
using AdventOfCodeCommon;

namespace AdventOfCode2025;

public class Day1 : IPuzzle
{
    public string GetPart1Result(string[] inputs)
    {
        var timesAtZero = 0;
        var number = 50;
        foreach (var input in inputs)
        {
            // Mod 100 to handle multile full rotations
            var offset = parseInput(input) % 100;
            number = normalizeNumber(number + offset);
            if (number == 0)
            {
                timesAtZero++;
            }
        }
        return timesAtZero.ToString();
    }

    public string GetPart2Result(string[] inputs)
    {
        var timesAtZero = 0;
        var number = 50;
        foreach (var input in inputs)
        {
            var offset = parseInput(input);
            var nextNumber = number + (offset % 100);

            // Add one if we don't start at zero and we cross zero
            timesAtZero += (number != 0 && (nextNumber <= 0 || nextNumber >= 100)) ? 1 : 0;

            // Add all full cycles of 100 crossed
            timesAtZero += (int)Math.Floor(Math.Abs(offset) / 100d);

            number = normalizeNumber(nextNumber);
        }
        return timesAtZero.ToString();
    }

    private int parseInput(string input)
    {
        return int.Parse(input.Substring(1)) * (input[0] == 'L' ? -1 : 1);
    }

    private int normalizeNumber(int number) 
    {
        if (number < 0)
        {
            return 100 + number;
        }
        if (number > 99)
        {
            return number - 100;
        }
        return number;
    }
}
