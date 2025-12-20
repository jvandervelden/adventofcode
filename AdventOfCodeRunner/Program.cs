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
            var year = null as int?;
            var day = null as int?;
            
            for (int i = 0; i < args.Length; i++)
            {
                

                if ("--year".Equals(args[i].ToLower()) || "-y".Equals(args[i].ToLower()))
                {
                    // Skip next argument as it's part of this flag
                    i++;
                    try { 
                        year = int.Parse(args[i]); 
                    }
                    catch (FormatException) 
                    { 
                        Console.WriteLine("Invalid year argument provided.");
                        return; 
                    }
                }
                else if ("--day".Equals(args[i].ToLower()) || "-d".Equals(args[i].ToLower()))
                {
                    // Skip next argument as it's part of this flag
                    i++;
                    try
                    {
                        day = int.Parse(args[i]);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid day argument provided.");
                        return;
                    }
                }
            }

            if (year.HasValue)
            {
                RunYear(year.Value, day);
            }
            else
            {
                // Process all available years
                int maxAvailableYear = DateTime.Now.Year - (DateTime.Now.Month == 12 ? 0 : 1);
                for (int i = ADVENT_OF_CODE_FIRST_YEAR; i <= maxAvailableYear; i++)
                {
                    RunYear(i);
                }
            }
        }

        static void RunYear(int year, int? day = null)
        {
            Console.WriteLine("Running Advent of Code for year {0}", year);
            if (day.HasValue)
            {
                Console.WriteLine("Running only day {0}", day.Value);
            }
            int startDay = day.HasValue ? day.Value : 1;
            int endDay = day.HasValue ? day.Value : ADVENT_OF_CODE_NUM_OF_DAYS;
            for (int i = (startDay - 1) * 2; i < endDay * 2; i++)
            {
                int dayToSolve = (i >> 1) + 1;
                int part = (i & 1) + 1;

                try
                {
                    Console.WriteLine("Year {0} Day {1} part {2} result: {3}", year, dayToSolve, part, RunPuzzle(year, dayToSolve, part));
                }
                catch (NotImplementedException)
                {
                    Console.WriteLine("Year {0} Day {1} part {2} not complete yet.", year, dayToSolve, part);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error running puzzle for year {0} day {1} and part {2}. Error: {3}", year, dayToSolve, part, e.Message);
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
