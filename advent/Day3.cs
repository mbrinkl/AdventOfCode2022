namespace advent;

public class Day3 : ProblemSet
{
    int a_Value;
    int A_Value;

    public Day3(string[] input) : base(input)
    {
        a_Value = 49;
        A_Value = 17;
    }

    protected override int P1()
    {
        var totalPriority = 0;

        foreach (var rucksack in input)
        {
            var compartment1 = rucksack[..(rucksack.Length / 2)];
            var compartment2 = rucksack.Substring(rucksack.Length / 2);

            var commonItem = compartment1.Intersect(compartment2).First();

            totalPriority += ComputePriority(commonItem);
        }

        return totalPriority;
    }


    protected override int P2()
    {
        var totalPriority = 0;

        for (int i = 0; i < input.Length; i += 3)
        {
            var rucksack1 = input[i];
            var rucksack2 = input[i + 1];
            var rucksack3 = input[i + 2];

            var commonItem = rucksack1.Intersect(rucksack2).Intersect(rucksack3).First();

            totalPriority += ComputePriority(commonItem);
        }

        return totalPriority;
    }

    private int ComputePriority(char item)
    {
        var number = item - '0';
        return number >= a_Value ? number - a_Value + 1 : number - A_Value + 27;
    }
}
