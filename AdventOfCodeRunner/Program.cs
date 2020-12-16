using AdventOfCodeCommon;
using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCodeRunner
{
    class Program
    {
        const int ADVENT_OF_CODE_FIRST_YEAR = 2015;
        const int ADVENT_OF_CODE_NUM_OF_DAYS = 25;

        static void Main(string[] args)
        {
            if (args.Length == 2 
                && (args[0].ToLower().Equals("-y") || args[0].ToLower().Equals("--year"))
                && int.TryParse(args[1], out int cmdLineYear))

                RunYear(cmdLineYear);
            else
            {
                // Process all available years
                int maxAvailableYear = DateTime.Now.Year - (DateTime.Now.Month == 12 ? 0 : 1);
                for (int year = ADVENT_OF_CODE_FIRST_YEAR; year <= maxAvailableYear; year++)
                {
                    RunYear(year);
                }
            }
        }

        static void RunYear(int year)
        {
            for (int i = 0; i < ADVENT_OF_CODE_NUM_OF_DAYS * 2; i++)
            {
                int day = (i >> 1) + 1;
                int part = (i & 1) + 1;

                try
                {
                    Console.WriteLine("Year {0} Day {1} part {2} result: {3}", year, day, part, RunPuzzle(year, day, part));
                }
                catch (NotImplementedException)
                {
                    Console.WriteLine("Year {0} Day {1} part {2} not complete yet.", year, day, part);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error running puzzle for year {0} day {1} and part {2}. Error: {3}", year, day, part, e.Message);
                    Console.WriteLine(e.StackTrace);
                }
            }
        }

        static string RunPuzzle(int year, int day, int part)
        {
            IPuzzle dayPuzzle = PuzzleFactory.GetPuzzle(year, day);
            string inputByDayFileLocation = $"./Input/{year}/day{day}.txt";
            string inputByPartFileLocation = $"./Input/{year}/day{day}-{part}.txt";
            string[] puzzleInput;

            if (File.Exists(inputByDayFileLocation))
                puzzleInput = File.ReadAllLines(inputByDayFileLocation);
            else if (File.Exists(inputByPartFileLocation))
                puzzleInput = File.ReadAllLines(inputByPartFileLocation);
            else 
                throw new ArgumentException($"Cannot load input for day {day}");


            return part switch
            {
                1 => dayPuzzle.GetPart1Result(puzzleInput),
                2 => dayPuzzle.GetPart2Result(puzzleInput),
                _ => throw new ArgumentOutOfRangeException($"Days can only have 2 parts.")
            };
        }
    }
}
