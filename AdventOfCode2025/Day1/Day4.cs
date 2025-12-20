using AdventOfCodeCommon;

namespace AdventOfCode2025;

public class Day4 : IPuzzle
{
    public string GetPart1Result(string[] inputs)
    {
        var availableRolls = updateRollsGrid(parseRollsGrid(inputs));

        return availableRolls.ToString();
    }

    public string GetPart2Result(string[] inputs)
    {
        var rollsGrid = parseRollsGrid(inputs);
        var rollsRemoved = 0;
        int rollsRemovedThisRound;
        int calculateCount = 0;

        do
        {
            rollsRemovedThisRound = updateRollsGrid(rollsGrid);
            rollsRemoved += rollsRemovedThisRound;
            calculateCount++;
        }
        while (rollsRemovedThisRound > 0 && calculateCount < 100);

        return rollsRemoved.ToString();
    }

    private char[][] parseRollsGrid(string[] inputs)
    {
        var rollsGrid = new char[inputs.Length][];
        for (int i = 0; i < inputs.Length; i++)
        {
            rollsGrid[i] = inputs[i].ToCharArray();
        }

        return rollsGrid;
    }

    private int updateRollsGrid(char[][] rollsGrid)
    {
        for (int i = 0; i < rollsGrid.Length; i++)
        {
            char[] line = rollsGrid[i];

            for (int j = 0; j < line.Length; j++)
            {
                char c = line[j];

                if (c == '@')
                {
                    var adjacentRolls = 0;
                    // x..
                    // .@.
                    // ... 
                    if (i > 0 && j > 0 && rollsGrid[i - 1][j - 1] != '.')
                    {
                        adjacentRolls++;
                    }
                    // x..
                    // .@.
                    // ...
                    if (i > 0 && rollsGrid[i - 1][j] != '.')
                    {
                        adjacentRolls++;
                    }
                    // ..x
                    // .@.
                    // ...
                    if (i > 0 && j < line.Length - 1 && rollsGrid[i - 1][j + 1] != '.')
                    {
                        adjacentRolls++;
                    }
                    // ...
                    // x@.
                    // ...
                    if (j > 0 && rollsGrid[i][j - 1] != '.')
                    {
                        adjacentRolls++;
                    }
                    // ...
                    // .@x
                    // ...
                    if (j < line.Length - 1 && rollsGrid[i][j + 1] != '.')
                    {
                        adjacentRolls++;
                    }
                    // ...
                    // .@.
                    // x..
                    if (i < rollsGrid.Length - 1 && j > 0 && rollsGrid[i + 1][j - 1] != '.')
                    {
                        adjacentRolls++;
                    }
                    // ...
                    // .@.
                    // .x.
                    if (i < rollsGrid.Length - 1 && rollsGrid[i + 1][j] != '.')
                    {
                        adjacentRolls++;
                    }
                    // ...
                    // .@.
                    // ..x
                    if (i < rollsGrid.Length - 1 && j < line.Length - 1 && rollsGrid[i + 1][j + 1] != '.')
                    {
                        adjacentRolls++;
                    }

                    if (adjacentRolls < 4)
                    {
                        rollsGrid[i][j] = 'x';
                    }
                }
            }
        }

        var rollsRemoved = 0;
        for (int i = 0; i < rollsGrid.Length; i++)
        {
            char[] line = rollsGrid[i];

            for (int j = 0; j < line.Length; j++)
            {
                if (line[j] == 'x')
                {
                    rollsGrid[i][j] = '.';
                    rollsRemoved++;
                }
            }
        }

        return rollsRemoved;
    }
}
