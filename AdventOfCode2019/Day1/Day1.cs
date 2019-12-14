using System.Linq;

using AdventOfCodeCommon;

namespace AdventOfCode2019
{
    public class Day1 : IPuzzle
    {
        public string GetPart1Result(string[] inputs)
        {
            return inputs.Sum((input) => CalculateModuleFuelRequirements(input)).ToString();
        }

        private int CalculateModuleFuelRequirements(string input)
        {
            int mass = int.Parse(input);

            return mass / 3 - 2;
        }

        public int CalculateExtraFuelRequirements(int extraMass) 
        {
            if (extraMass < 9)
                return 0;

            int fuelRequirements = extraMass / 3 - 2;

            return fuelRequirements + CalculateExtraFuelRequirements(fuelRequirements);
        }

        public string GetPart2Result(string[] inputs)
        {
            return inputs.Sum((input) => {
                int fuelMass = CalculateModuleFuelRequirements(input);
                return fuelMass + CalculateExtraFuelRequirements(fuelMass);
            }).ToString();
        }
    }
}