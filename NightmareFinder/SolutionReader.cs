using static Core.WordleSquareType;

namespace NightmareFinder;

public static class SolutionReader
{
    public static bool IsBlackSquare(string s)
    {
        return s.Equals(Black);
    }

    public static bool IsYellowSquare(string s)
    {
        return s.Equals(Yellow);
    }

    public static bool IsGreenSquare(string s)
    {
        return s.Equals(Green);
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