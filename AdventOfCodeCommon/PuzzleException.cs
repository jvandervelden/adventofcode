using System;

namespace AdventOfCodeCommon
{
    public class PuzzleException : Exception {
        public PuzzleException(string message) : base(message) {}
    }
}