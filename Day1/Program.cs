// See https://aka.ms/new-console-template for more information

var lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "input"));

var biggestElf = 0;
var newElf = 0;

foreach (var line in lines)
{
    if (!string.IsNullOrWhiteSpace(line))
    {
        newElf += int.Parse(line);
        continue;
    }

    if (biggestElf < newElf)
    {
        biggestElf = newElf;
    }

    newElf = 0;
}

Console.WriteLine("Biggest elf carry: {0}", biggestElf);