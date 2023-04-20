using System.Threading.Tasks.Sources;
using Shouldly;

namespace Tests;

public class CoreTests
{
    [Fact]
    public void ShouldFindGreenSquare()
    {
        var greenSquare = "🟩";
        SolutionReader.IsGreenSquare(greenSquare).ShouldBeTrue();
        SolutionReader.IsBlackSquare(greenSquare).ShouldBeFalse();
        SolutionReader.IsYellowSquare(greenSquare).ShouldBeFalse();
    }

    [Fact]
    public void ShouldFindYellowSquare()
    {
        var yellowSquare = "🟨";
        SolutionReader.IsGreenSquare(yellowSquare).ShouldBeFalse();
        SolutionReader.IsBlackSquare(yellowSquare).ShouldBeFalse();
        SolutionReader.IsYellowSquare(yellowSquare).ShouldBeTrue();
    }

    [Fact]
    public void ShouldFindBlackSquare()
    {
        var blackSquare = "⬛️";
        SolutionReader.IsGreenSquare(blackSquare).ShouldBeFalse();
        SolutionReader.IsBlackSquare(blackSquare).ShouldBeTrue();
        SolutionReader.IsYellowSquare(blackSquare).ShouldBeFalse();
    }
    
    [Fact]
    public void ShouldMatchRepeatedLines()
    {
        var lines = new string[] { "G,G,G,X,G", "G,G,G,X,G" };
        SolutionReader.TwoLinesMatch(lines).ShouldBeTrue();
    }
    
    [Fact]
    public void ShouldMatchLastThreeLines()
    {
        var lines = new string[]
        {
            "G,G,X,X,G",
            "G,X,G,X,G", 
            "G,X,X,X,G",
            "G,G,G,X,G",
            "G,G,G,X,G", 
            "G,G,G,X,G",
        };
        
        SolutionReader.LastThreeLinesMatch(lines).ShouldBeTrue();
    }
    
    [Fact]
    public void ShouldNotMatchLastThreeLines()
    {
        var lines = new string[]
        {
            "G,G,X,X,G",
            "G,X,G,X,G", 
            "G,X,X,X,G",
            "G,G,G,X,G",
            "G,G,G,X,G", 
            "G,G,G,G,G",
        };
        
        SolutionReader.LastThreeLinesMatch(lines).ShouldBeFalse();
    }
    
    
    [Theory]
    [InlineData(0, new string[]{"🟨","🟨","🟨","🟨","🟨"})]
    [InlineData(1, new string[]{"🟨","🟨","🟨","🟨","🟩"})]
    [InlineData(2, new string[]{"🟨","🟨","🟨","🟩","🟩"})]
    [InlineData(3, new string[]{"🟨","🟨","🟩","🟩","🟩"})]
    [InlineData(4, new string[]{"🟨","🟩","🟩","🟩","🟩"})]
    [InlineData(5, new string[]{"🟩","🟩","🟩","🟩","🟩"})]
    public void ShouldReturnGreenSquareCount(int expected, string[] line)
    {
        SolutionReader.GreenSquareCount(line).ShouldBe(expected);
    }

}

public static class SolutionReader
{
    public static bool IsBlackSquare(string s)
    {
        return s.Equals("⬛️");
    }   
    public static bool IsYellowSquare(string s)
    {
        return s.Equals("🟨");
    }
    public static bool IsGreenSquare(string s)
    {
        return s.Equals("🟩");
    }

    public static bool TwoLinesMatch(string[] lines)
    {
        var ret = lines[0].Equals(lines[1]);
        return ret;
    }

    /// <summary>
    /// This is essentially a Wordle Nightmare!!!
    ///
    /// Assumptions: Text has been pre-read and this is only hit when it's confirmed to be a wipe out.
    /// </summary>
    /// <param name="lines"></param>
    /// <returns></returns>
    public static bool LastThreeLinesMatch(string[] lines)
    {
        var items = lines.Reverse().ToList();    // get them ordered to see the last ones 
        var pattern = items.Take(1).ToList()[0];    // get the first pattern to match
        var isMatch = true;
        
        for (int i = 0; i < 3; i++)
        {
            isMatch = isMatch && pattern.Equals(items[i]);
        }

        return isMatch;
    }

    public static int GreenSquareCount(string[] line)
    {
        var vals = line.Select(x => x);
        
        return vals.Count(IsGreenSquare);
    }
}

