using System;
using System.Collections.Generic;
using System.Linq;

using AdventOfCodeCommon;

namespace AdventOfCode2019
{
    public class Day3 : IPuzzle
    {
        
        public string GetPart1Result(string[] inputs)
        {
            IEnumerable<Tuple<Direction, int>> wire1Moves = inputs[0].Split(',').Select(ParseMove);
            IEnumerable<Tuple<Direction, int>> wire2Moves = inputs[1].Split(',').Select(ParseMove);

            HashSet<string> visitedLocations = new HashSet<string>();
            int minManhattanDistance = Int32.MaxValue;

            TraceWires(wire1Moves, (x, y, location, steps) => visitedLocations.Add(location));
            TraceWires(wire2Moves, (x, y, location, steps) => {
                if (visitedLocations.Contains(location)) {
                    visitedLocations.Remove(location);
                    int manhattanDistance = Math.Abs(x) + Math.Abs(y);
                    if (minManhattanDistance > manhattanDistance)
                        minManhattanDistance = manhattanDistance;
                }
            });

            return minManhattanDistance.ToString();
        }

        private void TraceWires(IEnumerable<Tuple<Direction, int>> wire1Moves, Action<int, int, string, int> cb)
        {
            int x = 0;
            int y = 0;
            int steps = 1;

            foreach (Tuple<Direction, int> move in wire1Moves)
            {
                for (int i = 0; i < move.Item2; i++)
                {
                    switch (move.Item1) {
                        case Direction.UP: y++; break;
                        case Direction.DOWN: y--; break;
                        case Direction.LEFT: x--; break;
                        case Direction.RIGHT: x++; break;
                    }

                    string location = $"{x}-{y}";
                    
                    cb(x, y, location, steps++);
                }
            }
        }

        private enum Direction
        {
            UP, DOWN, LEFT, RIGHT
        }

        private Direction ParseDirection(char value)
        {
            switch(value) {
                case 'U': return Direction.UP;
                case 'D': return Direction.DOWN;
                case 'L': return Direction.LEFT;
                case 'R': return Direction.RIGHT;
            }

            throw new Exception($"Cannot parse {value} into a Direction");
        }

        private Tuple<Direction, int> ParseMove(string move) {
            return new Tuple<Direction, int>(ParseDirection(move.ElementAt(0)), int.Parse(move.Substring(1)));
        }

        public string GetPart2Result(string[] inputs)
        {
            IEnumerable<Tuple<Direction, int>> wire1Moves = inputs[0].Split(',').Select(ParseMove);
            IEnumerable<Tuple<Direction, int>> wire2Moves = inputs[1].Split(',').Select(ParseMove);

            Dictionary<string, int> visitedLocations = new Dictionary<string, int>();
            int minSteps = Int32.MaxValue;

            TraceWires(wire1Moves, (x, y, location, steps) => { 
                if (!visitedLocations.ContainsKey(location))
                    visitedLocations[location] = steps;
            });
            TraceWires(wire2Moves, (x, y, location, steps) => {
                if (visitedLocations.ContainsKey(location)) {
                    
                    int totalSteps = steps + visitedLocations[location];
                    if (minSteps > totalSteps)
                        minSteps = totalSteps;

                    visitedLocations.Remove(location);
                }
            });

            return minSteps.ToString();
        }
    }
}