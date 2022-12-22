using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.Year2022
{
    public class Day01 : IResolvable
    {
        private readonly List<int> _elfs = new();
        private readonly string[] _file = File.ReadAllLines("./Year2022/Day01/input.txt");
        private int _calories = 0;
        public string SolvePartOne()
        {
            foreach (var line in _file)
            {
                if (string.IsNullOrEmpty(line))
                {
                    _elfs.Add(_calories);
                    _calories = 0;
                }
                else
                {
                    _calories += int.Parse(line);
                }
            }
            var maxCalories = _elfs.Max();
            return maxCalories.ToString();
        }
        public string SolvePartTwo()
        {
            _elfs.Sort();
            return _elfs.TakeLast(3).Sum().ToString();
        }
    }
}