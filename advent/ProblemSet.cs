namespace advent;

public abstract class ProblemSet
{
    protected string[] input;

    public ProblemSet(string[] input)
    {
        this.input = input;
    }

    public void Solve()
    {
        var solution1 = P1();
        var solution2 = P2();
        Console.WriteLine("Solutions:");
        Console.WriteLine($"P1: {solution1}");
        Console.WriteLine($"P2: {solution2}");
    }

    protected abstract int P1();

    protected abstract int P2();
}
