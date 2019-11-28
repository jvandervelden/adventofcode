using AdventOfCode2015;
using AdventOfCodeCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace AdventOfCodeRunner
{
    public static class PuzzleFactory
    {
        private static ISet<int> _loadedPuzzleAssemblies = new HashSet<int>();

        public static IPuzzle GetPuzzle(int year, int day)
        {
            string assemblyName = $"AdventOfCode{year}";
            if (!_loadedPuzzleAssemblies.Contains(year))
            {
                Assembly.LoadFile(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + $"/{assemblyName}.dll");
                _loadedPuzzleAssemblies.Add(year);
            }

            Type puzzleClass = Type.GetType($"AdventOfCode{year}.Day{day}, {assemblyName}");

            if (puzzleClass == null || !typeof(IPuzzle).IsAssignableFrom(puzzleClass))
                throw new NotImplementedException($"Puzzle {year} - {day} not implemented yet");

            return (IPuzzle)Activator.CreateInstance(puzzleClass);
        }
    }
}
