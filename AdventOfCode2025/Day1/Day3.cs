using AdventOfCodeCommon;

namespace AdventOfCode2025;

public class Day3 : IPuzzle
{
    public string GetPart1Result(string[] inputs)
    {
        var totalJoltage = 0;
        foreach (var input in inputs) {
            var firstNumberIndex = findFirstLargestIndex(input, 1);
            var secondNumberIndex = findFirstLargestIndex(input.Substring(firstNumberIndex.Item1 + 1), 0);
            var joltage = firstNumberIndex.Item2 + secondNumberIndex.Item2;

            totalJoltage += int.Parse(joltage);
        }

        return totalJoltage.ToString();
    }

    public string GetPart2Result(string[] inputs)
    {
        var totalJoltage = 0L;
        foreach (var input in inputs) {
            var inputJoltage = "";
            var currentInputIndex = 0;
            for(int i = 11; i >= 0; i--) {
                var numberIndex = findFirstLargestIndex(input.Substring(currentInputIndex), i);
                currentInputIndex += numberIndex.Item1 + 1;
                inputJoltage = inputJoltage + numberIndex.Item2;
            }

            totalJoltage += long.Parse(inputJoltage.ToString());
        }

        return totalJoltage.ToString();
    }

    private Tuple<int, string> findFirstLargestIndex(string input, int trimEnd) {
        var largestNumber = 0;
        var largestNumberIndex = 0;
        for (int i = 0; i < input.Length - trimEnd; i++) {
            var currentNumber = int.Parse(input[i] + "");
            if (currentNumber > largestNumber) {
                largestNumber = currentNumber;
                largestNumberIndex = i;
            }
        }
        return new Tuple<int, string>(largestNumberIndex, largestNumber.ToString());
    }
}
