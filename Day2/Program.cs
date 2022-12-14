// See https://aka.ms/new-console-template for more information

var lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "input"));

Version1(lines);
Version2(lines);

void Version2(IEnumerable<string> strings)
{
    // SHAPE    | CODE | STRATEGY   | VALUE
    // Rock     | A    | X lose     | 1
    // Paper    | B    | Y draw     | 2
    // Scissors | C    | Z win      | 3

    // { SCENARIO, strategy + shapeValue }  
    Dictionary<string, int> Options = new()
    {
        {"A X", 0 +  3}, // fail + scissors
        {"B X", 0 +  1}, // fail + rock
        {"C X", 0 +  2}, // fail + paper
        {"A Y", 3 +  1}, // draw + rock
        {"B Y", 3 +  2}, // draw + paper
        {"C Y", 3 +  3}, // draw + scissors
        {"A Z", 6 +  2}, // win + paper
        {"B Z", 6 +  3}, // win + scissors
        {"C Z", 6 +  1}, // win + rock
    };

    var sum = strings.Sum(line => Options[line]);

    Console.WriteLine("Total points V2 would be: {0}", sum);
}

void Version1(IEnumerable<string> strings)
{
    // SHAPE    | CODE (OPPONENT/ME)    | VALUE
    // Rock     | A/X                   | 1
    // Paper    | B/Y                   | 2
    // Scissors | C/Z                   | 3

    // { SCENARIO, result + shapeValue }  
    Dictionary<string, int> Options = new()
    {
        {"A X", 3 + 1}, // draw RxR
        {"B X", 0 + 1}, // fail PxR
        {"C X", 6 + 1}, // win  SxR
        {"A Y", 6 + 2}, // win  RxP
        {"B Y", 3 + 2}, // draw PxP
        {"C Y", 0 + 2}, // fail SxP
        {"A Z", 0 + 3}, // fail RxS
        {"B Z", 6 + 3}, // win  PxS
        {"C Z", 3 + 3}, // draw SxS
    };

    var sum = strings.Sum(line => Options[line]);

    Console.WriteLine("Total points would be: {0}", sum);
}