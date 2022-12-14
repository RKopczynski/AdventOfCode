// See https://aka.ms/new-console-template for more information
var lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "input"));

GetTopElf(lines);
GetTop3Elves(lines);

void GetTop3Elves(IEnumerable<string> lines)
{
    var elves = new List<int>();
    using var enumerator = lines.GetEnumerator();
    
    while (GetNextElf(enumerator, out var elf))
    {
        elves.Add(elf);
    }

    var top3Elves = elves.OrderByDescending(e => e)
        .Take(3)
        .Aggregate((a, b) => a + b);
    
    Console.WriteLine("Top 3 elves weight {0}", top3Elves);

    static bool GetNextElf(IEnumerator<string> elfEnumerator, out int elf)
    {
        elf = 0;
        var next = string.Empty;

        do
        {
            if (!elfEnumerator.MoveNext())
                return false;

            next = elfEnumerator.Current;
            if (string.IsNullOrWhiteSpace(next))
            {
                break;
            }

            elf += int.Parse(next);
        } while (true);

        return true;
    }
}

void GetTopElf(IEnumerable<string> lines)
{
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
}