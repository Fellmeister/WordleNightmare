using Shouldly;
using static Tests.SolutionReader;
using static Tests.WordleSquareType;

namespace Tests;

public class CoreTests
{
    [Fact]
    public void ShouldFindGreenSquare()
    {
        var greenSquare = Green;
        IsGreenSquare(greenSquare).ShouldBeTrue();
        IsBlackSquare(greenSquare).ShouldBeFalse();
        IsYellowSquare(greenSquare).ShouldBeFalse();
    }

    [Fact]
    public void ShouldFindYellowSquare()
    {
        var yellowSquare = Yellow;
        IsGreenSquare(yellowSquare).ShouldBeFalse();
        IsBlackSquare(yellowSquare).ShouldBeFalse();
        IsYellowSquare(yellowSquare).ShouldBeTrue();
    }

    [Fact]
    public void ShouldFindBlackSquare()
    {
        var blackSquare = Black;
        IsGreenSquare(blackSquare).ShouldBeFalse();
        IsBlackSquare(blackSquare).ShouldBeTrue();
        IsYellowSquare(blackSquare).ShouldBeFalse();
    }

    [Theory]
    [InlineData(0, new[] { Yellow, Yellow, Yellow, Yellow, Yellow })]
    [InlineData(1, new[] { Yellow, Yellow, Yellow, Yellow, Green })]
    [InlineData(2, new[] { Yellow, Yellow, Yellow, Green, Green })]
    [InlineData(3, new[] { Yellow, Yellow, Green, Green, Green })]
    [InlineData(4, new[] { Yellow, Green, Green, Green, Green })]
    [InlineData(5, new[] { Green, Green, Green, Green, Green })]
    [InlineData(0, new[] { Black, Black, Black, Black, Black })]
    [InlineData(1, new[] { Black, Black, Black, Black, Green })]
    [InlineData(2, new[] { Black, Black, Black, Green, Green })]
    [InlineData(3, new[] { Black, Black, Green, Green, Green })]
    [InlineData(4, new[] { Black, Green, Green, Green, Green })]
    [InlineData(5, new[] { Green, Green, Green, Green, Green })]
    public void ShouldReturnGreenSquareCount(int expected, string[] line)
    {
        GreenSquareCount(line).ShouldBe(expected);
    }

    [Fact]
    public void ShouldReturnTrueIfWordleNightmare()
    {
        var lines = new []
        {
            new[] { Yellow, Yellow, Yellow, Yellow, Yellow },
            new[] { Yellow, Yellow, Yellow, Yellow, Green },
            new[] { Yellow, Yellow, Yellow, Green, Green },
            new[] { Yellow, Yellow, Green, Green, Green },
            new[] { Yellow, Yellow, Green, Green, Green },
            new[] { Yellow, Yellow, Green, Green, Green },
        };

        IsWordleNightmare(lines).ShouldBeTrue();
    }
    
    [Fact]
    public void ShouldReturnFalseIfNotWordleNightmare()
    {
        var lines = new []
        {
            new[] { Yellow, Yellow, Yellow, Yellow, Yellow },
            new[] { Yellow, Yellow, Yellow, Yellow, Green },
            new[] { Yellow, Yellow, Yellow, Green, Green },
            new[] { Yellow, Yellow, Green, Green, Green },
            new[] { Yellow, Green, Yellow, Green, Green },
            new[] { Yellow, Yellow, Green, Green, Green },
        };

        IsWordleNightmare(lines).ShouldBeFalse();
    }
}