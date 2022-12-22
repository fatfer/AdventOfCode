using System.Reflection;

using AdventOfCode;

using Spectre.Console;

var table = new Table();
table.Border = TableBorder.MinimalHeavyHead;
TableTitle title = new("[green]ADVENT OF CODE[/]");
table.Title = title;
table.AddColumn("[green]Day[/]");
table.AddColumn("[green]Part1[/]");
table.AddColumn("[green]Part2[/]");

foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
{
    if (type.GetInterfaces().Contains(typeof(IResolvable)))
    {
        object? instance = Activator.CreateInstance(type);
        var part1 = string.Empty;
        var part2 = string.Empty;

        MethodInfo? method = type.GetMethod("SolvePartOne");
        if (method != null)
        {
            part1 = method.Invoke(instance, null) + "";
        }

        method = type.GetMethod("SolvePartTwo");
        if (method != null)
        {
            part2 = method.Invoke(instance, null) + "";
        }

        table.AddRow($"{instance}", $"[yellow]{part1}[/]", $"[yellow]{part2}[/]");
    }
}

AnsiConsole.Write(table);
