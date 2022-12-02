using System.Reflection;
using advent;

var assemblyTypes = Assembly.GetExecutingAssembly().GetTypes();

int day = DateTime.Now.Day;
int maxDay = 25;
day = Math.Min(day, maxDay);

async void SolveDay(int day)
{
    try
    {
        var input = await File.ReadAllLinesAsync(@$"inputs\day{day}.txt");
        var problemArgs = new object[] { input };
        var type = assemblyTypes.FirstOrDefault((t) => t.Name.Equals($"Day{day}"));

        var problemSet = (ProblemSet)Activator.CreateInstance(type, problemArgs);
        problemSet.Solve();
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine($"No input file found for day {day}");
    }
    catch (ArgumentNullException)
    {
        Console.WriteLine($"ProblemSet class not found for day {day}");
    }
}

while (true)
{
    Console.Clear();

    Console.WriteLine($"Day: {day}");
    Console.WriteLine($"Up/Right Arrow: day++");
    Console.WriteLine($"Down/Left Arrow: day--");
    Console.WriteLine();

    SolveDay(day);

    var key = Console.ReadKey().Key;

    if (key == ConsoleKey.UpArrow || key == ConsoleKey.RightArrow)
    {
        if (day < maxDay)
        {
            day++;
        }
        continue;
    }
    else if (key == ConsoleKey.DownArrow || key == ConsoleKey.LeftArrow)
    {
        if (day > 1)
        {
            day--;
        }
        continue;
    }
}
