using System.Text.RegularExpressions;

namespace AdventOfCode.Year2023;

public class Day01 : IResolvable
{
    private readonly string[] _file = File.ReadAllLines("./Year2023/Day01/input.txt");
    private readonly Dictionary<string, int> _digitMapper = new Dictionary<string, int>
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 }
        };

    public string SolvePartOne()
    {
        return Solve(@"\d");
    }

    public string SolvePartTwo()
    {
        return Solve(@"\d|one|two|three|four|five|six|seven|eight|nine");
    }

    private string Solve(string pattern)
    {
        List<int> numbers = new();

        foreach (var line in _file)
        {
            var first = Regex.Match(line, pattern).Value;
            var second = Regex.Match(line, pattern, RegexOptions.RightToLeft).Value;
            string number = $"{ToDigit(first)}{ToDigit(second)}";
            numbers.Add(int.Parse(number));
        }
        return numbers.Sum().ToString();
    }

    private int ToDigit(string input)
    {
        return _digitMapper.TryGetValue(input, out int result) ? result : int.Parse(input);
    }
}