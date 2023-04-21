using static Tests.WordleConstants;

namespace Tests;

public static class SolutionReader
{
    public static bool IsBlackSquare(string s)
    {
        return s.Equals(BlackSquare);
    }

    public static bool IsYellowSquare(string s)
    {
        return s.Equals(YellowSquare);
    }

    public static bool IsGreenSquare(string s)
    {
        return s.Equals(GreenSquare);
    }

    /// <summary>
    /// This is NOT a Wordle Nightmare!!! It's missing a Green Square count!!!!!
    /// 
    /// Assumptions: Text has been pre-read and this is only hit when it's confirmed to be a wipe out.
    /// </summary>
    /// <param name="lines"></param>
    /// <returns></returns>
    public static bool LastThreeLinesMatch(string[][] lines)
    {
        var items = lines.Reverse().ToList(); // get them ordered to see the last ones 
        var pattern = items.Take(1).ToList()[0]; // get the first pattern to match
        var isMatch = true;

        for (int i = 0; i < 3; i++)
        {
            var temp = items[i];
            isMatch = isMatch && items[i].SequenceEqual(pattern);
        }

        return isMatch;
    }

    public static int GreenSquareCount(string[] line)
    {
        var vals = line.Select(x => x); // TODO this is awful

        return vals.Count(IsGreenSquare);
    }

    public static bool IsWordleNightmare(string[][] lines)
    {
        var items = lines.ToList(); // get them ordered to see the last ones 
        var lastLine = items.TakeLast(1).ToList()[0];
        var gsCount = GreenSquareCount(lastLine);
        var isMatch = true;

        for (int i = 5; i > 2; i--)
        {
            var temp = items[i];
            isMatch = isMatch && items[i].SequenceEqual(lastLine) && gsCount == GreenSquareCount(items[i]);
        }

        return isMatch;
    }
}