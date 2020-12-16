using AdventOfCodeCommon;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2015
{
    public class Day7 : IPuzzle
    {
        private enum WireOperand
        {
            AND, OR, LSHIFT, RSHIFT, NOT, ASSIGN
        }

        private static WireOperand WireOperandFromString(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return WireOperand.ASSIGN;

            switch (value.ToLower())
            {
                case "and":
                    return WireOperand.AND;
                case "or":
                    return WireOperand.OR;
                case "lshift":
                    return WireOperand.LSHIFT;
                case "rshift":
                    return WireOperand.RSHIFT;
                case "not":
                    return WireOperand.NOT;
                default:
                    throw new ArgumentException($"'{value}' is not a valid WireOperand");
            }
        }

        private class Wire
        {
            public string Identifier { get; set; }
            public WireOperand Operand { get; set; }
            public short? CalculatedValue { get; private set; } = null;
            public string Lhs { get; set; }
            public string Rhs { get; set; }

            private short GetSubSignalValue(string operandSide, Dictionary<string, Wire> wires)
            {
                if (string.IsNullOrWhiteSpace(operandSide)) return 0;
                if (short.TryParse(operandSide, out short sideValue)) return sideValue;
                if (wires.TryGetValue(operandSide, out Wire wire)) return wire.CalculateSignalValue(wires);

                return 0;
            }

            public short CalculateSignalValue(Dictionary<string, Wire> wires)
            {
                if (CalculatedValue.HasValue) return CalculatedValue.Value;

                short lhsValue = GetSubSignalValue(Lhs, wires);
                short rhsValue = GetSubSignalValue(Rhs, wires);

                switch (Operand)
                {
                    case WireOperand.AND:
                        CalculatedValue = (short)(lhsValue & rhsValue);
                        break;
                    case WireOperand.OR:
                        CalculatedValue = (short)(lhsValue | rhsValue);
                        break;
                    case WireOperand.LSHIFT:
                        CalculatedValue = (short)(lhsValue << rhsValue);
                        break;
                    case WireOperand.RSHIFT:
                        CalculatedValue = (short)(lhsValue >> rhsValue);
                        break;
                    case WireOperand.NOT:
                        CalculatedValue = (short)~rhsValue;
                        break;
                    case WireOperand.ASSIGN:
                        CalculatedValue = lhsValue;
                        break;
                }

                return CalculatedValue.Value;
            }
        }

        private Wire ParseInput(string input)
        {
            Regex wireRegex = new Regex(@"^([0-9a-z]+)? ?(AND|OR|LSHIFT|RSHIFT|NOT)? ([0-9a-z]+)? ?-> (.+)$");
            Match wireMatch = wireRegex.Match(input);

            return new Wire()
            {
                Lhs = wireMatch.Groups[1].Value,
                Operand = WireOperandFromString(wireMatch.Groups[2].Value),
                Rhs = wireMatch.Groups[3].Value,
                Identifier = wireMatch.Groups[4].Value
            };
            
        }

        public string GetPart1Result(string[] inputList)
        {
            Dictionary<string, Wire> wires = new Dictionary<string, Wire>();

            foreach (string input in inputList)
            {
                Wire wire = ParseInput(input);
                wires.Add(wire.Identifier, wire);
            }

            return wires["a"].CalculateSignalValue(wires) + "";
        }

        public string GetPart2Result(string[] inputList)
        {
            Dictionary<string, Wire> wires = new Dictionary<string, Wire>();

            foreach (string input in inputList)
            {
                Wire wire = ParseInput(input);

                if (wire.Identifier == "b")
                    wire.Lhs = "16076";

                wires.Add(wire.Identifier, wire);
            }

            return wires["a"].CalculateSignalValue(wires) + "";
        }
    }
}
