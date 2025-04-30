using static NightmareFinder.Core.WordleSquareType;

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
        
        if (!HasWordleGameReachedMaxNumberOfLines(items)) return false;
        if (!HasCorrectNumberOfElementsInEveryLine(items)) return false;
        
        return HasLastThreeLinesOfWordleGameGotSamePattern(items);
    }

    private static bool HasLastThreeLinesOfWordleGameGotSamePattern(List<string[]> items)
    {
        var lastLine = items.TakeLast(1).ToList()[0];
        var gsCount = GreenSquareCount(lastLine);
        var lastLineIndex = 5;
        var minimumNightmareLineCount = 3;
        var isMatch = true;
        for (int i = lastLineIndex; i >= minimumNightmareLineCount; i--)
        {
            var temp = items[i];
            isMatch = isMatch && items[i].SequenceEqual(lastLine) && gsCount == GreenSquareCount(items[i]);
        }

        return isMatch;
    }

    private static bool HasCorrectNumberOfElementsInEveryLine(List<string[]> items)
    {
        const int expectedLineLength = 5;
        foreach (var item in items)
        {
            if (item.Length != expectedLineLength)
            {
                return false;
            }
        }

        return true;
    }

    private static bool HasWordleGameReachedMaxNumberOfLines(List<string[]> items)
    {
        var maximumWordleLinesAllowed = 6;
        if (items.Count < maximumWordleLinesAllowed)
        {
            return false;
        }

        return true;
    }
}