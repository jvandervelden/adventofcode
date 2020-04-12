using System;
using System.Collections.Generic;
using System.Linq;

using AdventOfCodeCommon;

namespace AdventOfCode2019
{
    public class Day2 : IPuzzle
    {
        private class Cpu 
        {
            public bool Halted { get; private set; } = false;

            private int[] _ramBackup;
            private int[] _ram;
            private int _pc = 0;

            public Cpu(int[] ram)
            {
                _ram = ram;
                _ramBackup = new int[_ram.Length];
                _ram.CopyTo(_ramBackup, 0);
            }

            public int ReadRam(int address)
            {
                return _ram[address];
            }

            public void WriteRam(int address, int value)
            {
                _ram[address] = value;
            }

            public void Reset()
            {
                _ramBackup.CopyTo(_ram, 0);
                _pc = 0;
                Halted = false;
            }

            public bool Clock() 
            {
                if (Halted)
                    return true;

                int opcode = _ram[_pc++];
                int lhs = _ram[_pc++];
                int rhs = _ram[_pc++];
                int res = _ram[_pc++];
                
                switch(opcode)
                {
                    case 1:
                        _ram[res] = _ram[lhs] + _ram[rhs];
                        break;
                    case 2:
                        _ram[res] = _ram[lhs] * _ram[rhs];
                        break;
                    case 99:
                        Halted = true;
                        break;
                }

                return Halted;
            }
        }

        public string GetPart1Result(string[] inputs)
        {
            Cpu cpu = new Cpu(ParseRam(inputs[0]));

            cpu.WriteRam(1, 12);
            cpu.WriteRam(2, 2);

            while (!cpu.Clock()) { }

            return cpu.ReadRam(0).ToString();
        }

        private int[] ParseRam(string input) 
        {
            return input.Split(',').Select(int.Parse).ToArray();
        }

        private int CalcGravityAssist(Cpu cpu, int noun, int verb)
        {
            cpu.Reset();
            cpu.WriteRam(1, noun);
            cpu.WriteRam(2, verb);

            while (!cpu.Clock()) { }

            return cpu.ReadRam(0);
        }

        public string GetPart2Result(string[] inputs)
        {
            Cpu cpu = new Cpu(ParseRam(inputs[0]));
            
            for (int noun = 0; noun <= 99; noun++)
                for (int verb = 0; verb <= 99; verb++)
                    if (CalcGravityAssist(cpu, noun, verb) == 19690720)
                        return (noun * 100 + verb).ToString();

            throw new Exception("Couldn't find noun verb for part 2.");
        }
    }
}