using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCodeCommon
{
    public interface IPuzzle
    {
        string GetPart1Result(string[] input);
        string GetPart2Result(string[] input);
    }
}
