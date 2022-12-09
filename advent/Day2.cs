namespace advent;

public class Day2 : ProblemSet
{
    enum Shape
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }

    int lossScore;
    int drawScore;
    int winScore;
    Dictionary<string, Shape> shapeDict;

    public Day2(string[] input) : base(input)
    {
        shapeDict = new Dictionary<string, Shape>
        {
            { "A", Shape.Rock },
            { "X", Shape.Rock },
            { "B", Shape.Paper },
            { "Y", Shape.Paper },
            { "C", Shape.Scissors },
            { "Z", Shape.Scissors },
        };

        lossScore = 0;
        drawScore = 3;
        winScore = 6;
    }

    protected override int P1()
    {
        var totalScore = 0;

        foreach (var line in input)
        {
            var split = line.Split(" ");

            var opponentShape = shapeDict[split[0]];
            var myShape = shapeDict[split[1]];

            var outcome = GetOutcome(opponentShape, myShape);

            var score = (int)myShape + outcome;

            totalScore += score;
        }

        return totalScore;
    }


    protected override int P2()
    {
        var totalScore = 0;

        foreach (var line in input)
        {
            var split = line.Split(" ");

            var opponentShape = shapeDict[split[0]];
            var score = GetOutcome(opponentShape, split[1]);

            totalScore += score;
        }

        return totalScore;
    }

    private int GetOutcome(Shape s1, Shape s2)
    {
        // Draw
        if (s1 == s2)
        {
            return drawScore;
        }


        // Win for s2
        if (s1 == Shape.Rock && s2 == Shape.Paper ||
            s1 == Shape.Paper && s2 == Shape.Scissors ||
            s1 == Shape.Scissors && s2 == Shape.Rock)
        {
            return winScore;
        }

        // Loss for s2
        return lossScore;
    }

    private int GetOutcome(Shape s1, string roundEnd)
    {
        var score = -1;

        switch(roundEnd)
        {
            // Must lose
            case "X":
                score = lossScore;
                if (s1 == Shape.Rock) score += (int)Shape.Scissors;
                else if (s1 == Shape.Paper) score += (int)Shape.Rock;
                else if (s1 == Shape.Scissors) score += (int)Shape.Paper;
                break;
            // Must draw
            case "Y":
                score = drawScore + (int)s1;
                break;
            // Must win
            case "Z":
                score = winScore;
                if (s1 == Shape.Rock) score += (int)Shape.Paper;
                else if (s1 == Shape.Paper) score += (int)Shape.Scissors;
                else if (s1 == Shape.Scissors) score += (int)Shape.Rock;
                break;
            default:
                break;
        }

        return score;
    }
}
