using AdventOfCodeCommon;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day4 : IPuzzle
    {
        private static Regex _fieldRegex = new Regex(@"([^:\s]+):([^:\s]+)");
        private static Regex _heightRegex = new Regex(@"^(\d+)(?:cm|in)$");
        private static Regex _hairColorRegex = new Regex(@"^\#[a-fA-F0-9]{6}$");
        private static ISet<string> _eyeColors = new HashSet<string>(new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" });

        private struct Passport
        {
            public string BirthYear;
            public string IssueYear;
            public string ExpirationYear;
            public string Height;
            public string HairColor;
            public string EyeColor;
            public string PassportID;
            public string CountryID;

            public static Passport Parse(string input)
            {
                MatchCollection matches = _fieldRegex.Matches(input);
                IDictionary<string, string> fields = new Dictionary<string, string>();

                foreach (Match match in matches)
                    if (match.Success)
                        fields.Add(match.Groups[1].Value, match.Groups[2].Value);

                Func<IDictionary<string, string>, string, string, string> GetOrDefault = 
                    (IDictionary<string, string> fields, string key, string defaultValue) =>
                    {
                        return fields.ContainsKey(key) ? fields[key] : defaultValue;
                    };

                return new Passport
                {
                    BirthYear = GetOrDefault(fields, "byr", null),
                    IssueYear = GetOrDefault(fields, "iyr", null),
                    ExpirationYear = GetOrDefault(fields, "eyr", null),
                    Height = GetOrDefault(fields, "hgt", null),
                    HairColor = GetOrDefault(fields, "hcl", null),
                    EyeColor = GetOrDefault(fields, "ecl", null),
                    PassportID = GetOrDefault(fields, "pid", null),
                    CountryID = GetOrDefault(fields, "cid", null)
                };
            }

            private bool BetweenInclusive(long lhs, long mid, long rhs) => lhs <= mid && mid <= rhs;
            
            public bool IsValid()
            {
                try
                {
                    bool HeighValid = int.TryParse(_heightRegex.Match(Height).Groups[1].Value, out int height);
                    HeighValid = HeighValid && (Height.EndsWith("in")
                        ? BetweenInclusive(59, height, 76)
                        : BetweenInclusive(150, height, 193));
                    bool BirthYearValid = BirthYear.Length == 4 && BetweenInclusive(1920, long.Parse(BirthYear), 2020);
                    bool IssueYearValid = IssueYear.Length == 4 && BetweenInclusive(2010, long.Parse(IssueYear), 2020);
                    bool ExpirationYearValid = ExpirationYear.Length == 4 && BetweenInclusive(2020, long.Parse(ExpirationYear), 2030);
                    bool HairColorValid = _hairColorRegex.IsMatch(HairColor);
                    bool EyeColorValid = _eyeColors.Contains(EyeColor);
                    bool PassportIdValid = PassportID.Length == 9; long.Parse(PassportID);

                    return HeighValid &&
                        BirthYearValid &&
                        IssueYearValid &&
                        ExpirationYearValid &&
                        HairColorValid &&
                        EyeColorValid &&
                        PassportIdValid;
                }
                catch (FormatException)
                {
                    return false;
                }
            }

            public bool IsPresent()
            {
                return !(
                    string.IsNullOrWhiteSpace(BirthYear) ||
                    string.IsNullOrWhiteSpace(IssueYear) ||
                    string.IsNullOrWhiteSpace(ExpirationYear) ||
                    string.IsNullOrWhiteSpace(Height) ||
                    string.IsNullOrWhiteSpace(HairColor) ||
                    string.IsNullOrWhiteSpace(EyeColor) ||
                    string.IsNullOrWhiteSpace(PassportID));
            }
        }

        public string GetPart1Result(string[] input)
        {
            StringBuilder passportBatch = new StringBuilder();
            int validPassports = 0;

            foreach (string passportLine in input)
            {
                if (passportLine == "")
                {
                    if (Passport.Parse(passportBatch.ToString()).IsPresent())
                        validPassports++;
                    passportBatch.Clear();
                }
                else
                    passportBatch.Append(passportLine).Append(" ");
            }

            if (passportBatch.Length > 0 && Passport.Parse(passportBatch.ToString()).IsPresent())
                validPassports++;

            return $"{validPassports}";
        }

        public string GetPart2Result(string[] input)
        {
            StringBuilder passportBatch = new StringBuilder();
            int validPassports = 0;

            foreach (string passportLine in input)
            {
                if (passportLine == "")
                {
                    Passport passport = Passport.Parse(passportBatch.ToString());
                    if (passport.IsPresent() && passport.IsValid())
                        validPassports++;
                    passportBatch.Clear();
                }
                else
                    passportBatch.Append(passportLine).Append(" ");
            }

            if (passportBatch.Length > 0)
            {
                Passport passport = Passport.Parse(passportBatch.ToString());
                if (passport.IsPresent() && passport.IsValid())
                    validPassports++;
            }

            return $"{validPassports}";
        }
    }
}
