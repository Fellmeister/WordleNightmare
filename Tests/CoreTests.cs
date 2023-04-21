using Shouldly;
using static Tests.SolutionReader;
using static Tests.WordleConstants;

namespace Tests;

public class CoreTests
{
    [Fact]
    public void ShouldFindGreenSquare()
    {
        var greenSquare = GreenSquare;
        IsGreenSquare(greenSquare).ShouldBeTrue();
        IsBlackSquare(greenSquare).ShouldBeFalse();
        IsYellowSquare(greenSquare).ShouldBeFalse();
    }

    [Fact]
    public void ShouldFindYellowSquare()
    {
        var yellowSquare = YellowSquare;
        IsGreenSquare(yellowSquare).ShouldBeFalse();
        IsBlackSquare(yellowSquare).ShouldBeFalse();
        IsYellowSquare(yellowSquare).ShouldBeTrue();
    }

    [Fact]
    public void ShouldFindBlackSquare()
    {
        var blackSquare = BlackSquare;
        IsGreenSquare(blackSquare).ShouldBeFalse();
        IsBlackSquare(blackSquare).ShouldBeTrue();
        IsYellowSquare(blackSquare).ShouldBeFalse();
    }

    [Fact]
    public void ShouldMatchLastThreeLines()
    {
        var lines = new []
        {
            new[] { YellowSquare, YellowSquare, YellowSquare, YellowSquare, YellowSquare },
            new[] { YellowSquare, YellowSquare, YellowSquare, YellowSquare, GreenSquare },
            new[] { YellowSquare, YellowSquare, YellowSquare, GreenSquare, GreenSquare },
            new[] { YellowSquare, YellowSquare, GreenSquare, GreenSquare, GreenSquare },
            new[] { YellowSquare, YellowSquare, GreenSquare, GreenSquare, GreenSquare },
            new[] { YellowSquare, YellowSquare, GreenSquare, GreenSquare, GreenSquare },
        };

        LastThreeLinesMatch(lines).ShouldBeTrue();
    }

    [Fact]
    public void ShouldNotMatchLastThreeLines()
    {
        var lines = new []
        {
            new[] { YellowSquare, YellowSquare, YellowSquare, YellowSquare, YellowSquare },
            new[] { YellowSquare, YellowSquare, YellowSquare, YellowSquare, GreenSquare },
            new[] { YellowSquare, YellowSquare, YellowSquare, GreenSquare, GreenSquare },
            new[] { YellowSquare, YellowSquare, GreenSquare, GreenSquare, GreenSquare },
            new[] { YellowSquare, GreenSquare, YellowSquare, GreenSquare, GreenSquare },
            new[] { YellowSquare, YellowSquare, GreenSquare, GreenSquare, GreenSquare },
        };
            LastThreeLinesMatch(lines).ShouldBeFalse();
    }


    [Theory]
    [InlineData(0, new[] { YellowSquare, YellowSquare, YellowSquare, YellowSquare, YellowSquare })]
    [InlineData(1, new[] { YellowSquare, YellowSquare, YellowSquare, YellowSquare, GreenSquare })]
    [InlineData(2, new[] { YellowSquare, YellowSquare, YellowSquare, GreenSquare, GreenSquare })]
    [InlineData(3, new[] { YellowSquare, YellowSquare, GreenSquare, GreenSquare, GreenSquare })]
    [InlineData(4, new[] { YellowSquare, GreenSquare, GreenSquare, GreenSquare, GreenSquare })]
    [InlineData(5, new[] { GreenSquare, GreenSquare, GreenSquare, GreenSquare, GreenSquare })]
    [InlineData(0, new[] { BlackSquare, BlackSquare, BlackSquare, BlackSquare, BlackSquare })]
    [InlineData(1, new[] { BlackSquare, BlackSquare, BlackSquare, BlackSquare, GreenSquare })]
    [InlineData(2, new[] { BlackSquare, BlackSquare, BlackSquare, GreenSquare, GreenSquare })]
    [InlineData(3, new[] { BlackSquare, BlackSquare, GreenSquare, GreenSquare, GreenSquare })]
    [InlineData(4, new[] { BlackSquare, GreenSquare, GreenSquare, GreenSquare, GreenSquare })]
    [InlineData(5, new[] { GreenSquare, GreenSquare, GreenSquare, GreenSquare, GreenSquare })]
    public void ShouldReturnGreenSquareCount(int expected, string[] line)
    {
        GreenSquareCount(line).ShouldBe(expected);
    }

    [Fact]
    public void ShouldReturnTrueIfWordleNightmare()
    {
        var lines = new []
        {
            new[] { YellowSquare, YellowSquare, YellowSquare, YellowSquare, YellowSquare },
            new[] { YellowSquare, YellowSquare, YellowSquare, YellowSquare, GreenSquare },
            new[] { YellowSquare, YellowSquare, YellowSquare, GreenSquare, GreenSquare },
            new[] { YellowSquare, YellowSquare, GreenSquare, GreenSquare, GreenSquare },
            new[] { YellowSquare, YellowSquare, GreenSquare, GreenSquare, GreenSquare },
            new[] { YellowSquare, YellowSquare, GreenSquare, GreenSquare, GreenSquare },
        };

        IsWordleNightmare(lines).ShouldBeTrue();
    }
    
    [Fact]
    public void ShouldReturnFalseIfNotWordleNightmare()
    {
        var lines = new []
        {
            new[] { YellowSquare, YellowSquare, YellowSquare, YellowSquare, YellowSquare },
            new[] { YellowSquare, YellowSquare, YellowSquare, YellowSquare, GreenSquare },
            new[] { YellowSquare, YellowSquare, YellowSquare, GreenSquare, GreenSquare },
            new[] { YellowSquare, YellowSquare, GreenSquare, GreenSquare, GreenSquare },
            new[] { YellowSquare, GreenSquare, YellowSquare, GreenSquare, GreenSquare },
            new[] { YellowSquare, YellowSquare, GreenSquare, GreenSquare, GreenSquare },
        };

        IsWordleNightmare(lines).ShouldBeFalse();
    }
}