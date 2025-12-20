using System.Text.RegularExpressions;
using AdventOfCodeCommon;

namespace AdventOfCode2025;

public class Day2 : IPuzzle
{
    public string GetPart1Result(string[] inputs)
    {
        var finalCount = 0L;
        foreach (var input in inputs)
        {
            var ranges = parseInput(input);
            foreach (var range in ranges) {
                var idRanges = parseInputRange(range);

                for (long i = idRanges.Item1; i <= idRanges.Item2; i++)
                {
                    // Console.WriteLine(i);
                    if (isIdInvalid(i.ToString()))
                    {
                        finalCount += i;
                    }
                }
            }
        }

        return finalCount.ToString();
    }

    public string GetPart2Result(string[] inputs)
    {
        var finalCount = 0L;
        foreach (var input in inputs)
        {
            var ranges = parseInput(input);
            foreach (var range in ranges) {
                var idRanges = parseInputRange(range);

                for (long i = idRanges.Item1; i <= idRanges.Item2; i++)
                {
                    // Console.WriteLine(i);
                    if (isSequence(i.ToString()))
                    {
                        finalCount += i;
                    }
                }
            }
        }

        return finalCount.ToString();
    }

    private string[] parseInput(string input)
    {
        return input.Split(',');
    }

    private Tuple<long, long> parseInputRange(string input)
    {
        var parts = input.Split('-');
        return Tuple.Create(long.Parse(parts[0]), long.Parse(parts[1]));
    }

    private bool isSequence(string id)
    {
        for (int i = id.Length; i > 0; i--)
        {
            Regex regex = new Regex("^(.{" + i + "})\\1+$");
            if (regex.IsMatch(id))
            {
                return true;
            }
        }
        return false;
    }

    private Boolean isIdInvalid(string id)
    {
        // Console.WriteLine($"Checking ID: {id}");

        // If Length is odd, it can't be a double sequence and is valid
        if (id.Length % 2 != 0)
        {
            return false;
        }

        // Console.WriteLine($"ID: {id} even");

        // If the first half matches the second half, id is invalid
        var firstHalf = id.Substring(0, id.Length / 2);
        var secondHalf = id.Substring(id.Length / 2);

        // Console.WriteLine($"First Half: {firstHalf}, Second Half: {secondHalf}");

        return firstHalf == secondHalf;
    }
}
