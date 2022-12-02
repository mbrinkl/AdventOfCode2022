namespace advent;

public class Day1 : ProblemSet
{
    public Day1(string[] input) : base(input) { }

    protected override int P1()
    {
        var currentTotal = 0;
        var maxTotal = 0;
        foreach (var item in input)
        {
            if (String.IsNullOrEmpty(item))
            {
                currentTotal = 0;
                continue;
            }

            var value = Int32.Parse(item);
            currentTotal += value;

            maxTotal = Math.Max(currentTotal, maxTotal);
        }

        return maxTotal;
    }

    protected override int P2()
    {
        var currentTotal = 0;
        var highestTotals = new List<int>();

        foreach (var item in input)
        {
            if (String.IsNullOrEmpty(item))
            {
                SwapOutLowest(highestTotals, currentTotal);

                currentTotal = 0;

                continue;
            }

            var value = Int32.Parse(item);
            currentTotal += value;
        }

        SwapOutLowest(highestTotals, currentTotal);

        return highestTotals.Sum();
    }

    private static void SwapOutLowest(List<int> highestTotals, int replacement)
    {
        if (highestTotals.Count == 3)
        {
            var lowest = highestTotals.Min();
            if (replacement > lowest)
            {
                highestTotals.Remove(lowest);
                highestTotals.Add(replacement);
            }
        }
        else
        {
            highestTotals.Add(replacement);
        }
    }
}
