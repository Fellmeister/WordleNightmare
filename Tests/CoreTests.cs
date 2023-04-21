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
        var lines = new []
        {
            new string[] { "🟨", "🟨", "🟨", "🟨", "🟨" },
            new string[] { "🟨", "🟨", "🟨", "🟨", "🟩" },
            new string[] { "🟨", "🟨", "🟨", "🟩", "🟩" },
            new string[] { "🟨", "🟨", "🟩", "🟩", "🟩" },
            new string[] { "🟨", "🟨", "🟩", "🟩", "🟩" },
            new string[] { "🟨", "🟨", "🟩", "🟩", "🟩" },
        };

        SolutionReader.LastThreeLinesMatch(lines).ShouldBeTrue();
    }

    [Fact]
    public void ShouldNotMatchLastThreeLines()
    {
        var lines = new []
        {
            new string[] { "🟨", "🟨", "🟨", "🟨", "🟨" },
            new string[] { "🟨", "🟨", "🟨", "🟨", "🟩" },
            new string[] { "🟨", "🟨", "🟨", "🟩", "🟩" },
            new string[] { "🟨", "🟨", "🟩", "🟩", "🟩" },
            new string[] { "🟨", "🟩", "🟨", "🟩", "🟩" },
            new string[] { "🟨", "🟨", "🟩", "🟩", "🟩" },
        };
            SolutionReader.LastThreeLinesMatch(lines).ShouldBeFalse();
    }


    [Theory]
    [InlineData(0, new string[] { "🟨", "🟨", "🟨", "🟨", "🟨" })]
    [InlineData(1, new string[] { "🟨", "🟨", "🟨", "🟨", "🟩" })]
    [InlineData(2, new string[] { "🟨", "🟨", "🟨", "🟩", "🟩" })]
    [InlineData(3, new string[] { "🟨", "🟨", "🟩", "🟩", "🟩" })]
    [InlineData(4, new string[] { "🟨", "🟩", "🟩", "🟩", "🟩" })]
    [InlineData(5, new string[] { "🟩", "🟩", "🟩", "🟩", "🟩" })]
    [InlineData(0, new string[] { "⬛️", "⬛️", "⬛️", "⬛️", "⬛️" })]
    [InlineData(1, new string[] { "⬛️", "⬛️", "⬛️", "⬛️", "🟩" })]
    [InlineData(2, new string[] { "⬛️", "⬛️", "⬛️", "🟩", "🟩" })]
    [InlineData(3, new string[] { "⬛️", "⬛️", "🟩", "🟩", "🟩" })]
    [InlineData(4, new string[] { "⬛️", "🟩", "🟩", "🟩", "🟩" })]
    [InlineData(5, new string[] { "🟩", "🟩", "🟩", "🟩", "🟩" })]
    public void ShouldReturnGreenSquareCount(int expected, string[] line)
    {
        SolutionReader.GreenSquareCount(line).ShouldBe(expected);
    }

    [Fact]
    public void ShouldReturnTrueIfWordleNightmare()
    {
        var lines = new []
        {
            new string[] { "🟨", "🟨", "🟨", "🟨", "🟨" },
            new string[] { "🟨", "🟨", "🟨", "🟨", "🟩" },
            new string[] { "🟨", "🟨", "🟨", "🟩", "🟩" },
            new string[] { "🟨", "🟨", "🟩", "🟩", "🟩" },
            new string[] { "🟨", "🟨", "🟩", "🟩", "🟩" },
            new string[] { "🟨", "🟨", "🟩", "🟩", "🟩" },
        };

        SolutionReader.IsWordleNightmare(lines).ShouldBeTrue();
    }
    
    [Fact]
    public void ShouldReturnFalseIfNotWordleNightmare()
    {
        var lines = new []
        {
            new string[] { "🟨", "🟨", "🟨", "🟨", "🟨" },
            new string[] { "🟨", "🟨", "🟨", "🟨", "🟩" },
            new string[] { "🟨", "🟨", "🟨", "🟩", "🟩" },
            new string[] { "🟨", "🟨", "🟩", "🟩", "🟩" },
            new string[] { "🟨", "🟩", "🟨", "🟩", "🟩" },
            new string[] { "🟨", "🟨", "🟩", "🟩", "🟩" },
        };

        SolutionReader.IsWordleNightmare(lines).ShouldBeFalse();
    }
}