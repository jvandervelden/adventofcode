using AdventOfCodeCommon;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2015
{
    public class Day6 : IPuzzle
    {
        private enum LightAction {
            ON,
            OFF,
            TOGGLE
        }

        private struct Task {
            public static Task fromLine(string line) {
                Regex regex = new Regex(@"^(.+) (\d+),(\d+) through (\d+),(\d+)$", RegexOptions.None);

                Match taskItems = regex.Match(line);
                Task task = new Task();

                switch(taskItems.Groups[1].Value) {
                    case "turn off":
                        task.action = LightAction.OFF;
                        break;
                    case "turn on":
                        task.action = LightAction.ON;
                        break;
                    case "toggle":
                        task.action = LightAction.TOGGLE;
                        break;

                }

                task.xStart = int.Parse(taskItems.Groups[2].Value);
                task.yStart = int.Parse(taskItems.Groups[3].Value);
                task.xEnd = int.Parse(taskItems.Groups[4].Value);
                task.yEnd = int.Parse(taskItems.Groups[5].Value);

                return task;
            }

            public LightAction action;

            public int xStart;
            public int xEnd;
            public int yStart;
            public int yEnd;
        }

        private static int displayWidth = 1000;
        private static int displayHeight = 1000;

        int[,] lightArray = new int [displayWidth, displayHeight];

        public string GetPart1Result(string[] input)
        {
            foreach (string line in input) {
                Task task = Task.fromLine(line);

                processTask(task, (val) => {
                    switch(task.action) {
                        case LightAction.ON:
                            return 1;
                        case LightAction.OFF:
                            return 0;
                        case LightAction.TOGGLE:
                            return val == 1 ? 0 : 1;
                    }

                    throw new ArgumentException("Unable to process task action " + task.action);
                });
            }

            return countLightIllum() + "";
        }

        private void processTask(Task task, Func<int, int> newValueCallback) {
            for (int x = task.xStart; x <= task.xEnd; x++) {
                for (int y = task.yStart; y <= task.yEnd; y++) {
                    lightArray[x, y] = newValueCallback(lightArray[x, y]);

                }
            }            
        }

        private int countLightIllum() {
            int onCount = 0;

            for (int x = 0; x < displayWidth; x++) {
                for (int y = 0; y < displayHeight; y++) {
                    onCount += lightArray[x, y];
                }
            }

            return onCount;
        }

        public string GetPart2Result(string[] input)
        {
            foreach (string line in input) {
                Task task = Task.fromLine(line);

                processTask(task, (val) => {
                    switch(task.action) {
                        case LightAction.ON:
                            return val + 1;
                        case LightAction.OFF:
                            return Math.Max(0, val - 1);
                        case LightAction.TOGGLE:
                            return val + 2;
                    }

                    throw new ArgumentException("Unable to process task action " + task.action);
                });
            }

            return countLightIllum() + "";
        }
    }
}