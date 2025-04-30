using static NightmareFinder.Core.WordleSquareType;
using static NightmareFinder.SolutionReader;
using Shouldly;
using Xunit;

namespace NightmareFinder.Test;

public class SolutionReaderTests
{
    [Fact]
    public void ShouldFindGreenSquare()
    {
        // Arrange
        var greenSquare = Green;
        
        // Act & Assert
        IsGreenSquare(greenSquare).ShouldBeTrue();
        IsBlackSquare(greenSquare).ShouldBeFalse();
        IsYellowSquare(greenSquare).ShouldBeFalse();
    }

    [Fact]
    public void ShouldFindYellowSquare()
    {
        // Arrange
        var yellowSquare = Yellow;
        
        // Act & Assert
        IsGreenSquare(yellowSquare).ShouldBeFalse();
        IsBlackSquare(yellowSquare).ShouldBeFalse();
        IsYellowSquare(yellowSquare).ShouldBeTrue();
    }

    [Fact]
    public void ShouldFindBlackSquare()
    {
        // Arrange
        var blackSquare = Black;
        
        // Act & Assert
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
        // Act & Assert
        GreenSquareCount(line).ShouldBe(expected);
    }

    [Fact]
    public void ShouldReturnTrueIfWordleNightmare()
    {
        // Arrange
        var lines = new []
        {
            new[] { Yellow, Yellow, Yellow, Yellow, Yellow },
            new[] { Yellow, Yellow, Yellow, Yellow, Green },
            new[] { Yellow, Yellow, Yellow, Green, Green },
            new[] { Yellow, Yellow, Green, Green, Green },
            new[] { Yellow, Yellow, Green, Green, Green },
            new[] { Yellow, Yellow, Green, Green, Green },
        };

        // Act & Assert
        IsWordleNightmare(lines).ShouldBeTrue();
    }
    
    [Fact]
    public void ShouldReturnFalseIfNotWordleNightmare()
    {
        // Arrange
        var lines = new []
        {
            new[] { Yellow, Yellow, Yellow, Yellow, Yellow },
            new[] { Yellow, Yellow, Yellow, Yellow, Green },
            new[] { Yellow, Yellow, Yellow, Green, Green },
            new[] { Yellow, Yellow, Green, Green, Green },
            new[] { Yellow, Green, Yellow, Green, Green },
            new[] { Yellow, Yellow, Green, Green, Green },
        };

        // Act & Assert
        IsWordleNightmare(lines).ShouldBeFalse();
    }
    
    [Fact]
    public void ShouldReturnFalseIfOnlyFiveLines()
    {
        // Arrange
        var lines = new []
        {
            new[] { Yellow, Yellow, Yellow, Yellow, Green },
            new[] { Yellow, Yellow, Yellow, Green, Green },
            new[] { Yellow, Yellow, Green, Green, Green },
            new[] { Yellow, Green, Yellow, Green, Green },
            new[] { Yellow, Yellow, Green, Green, Green },
        };

        // Act & Assert
        IsWordleNightmare(lines).ShouldBeFalse();
    }
    
    [Fact]
    public void ShouldReturnFalseIfMoreThanSixLines()
    {
        // Arrange
        var lines = new []
        {
            new[] { Yellow, Yellow, Yellow, Yellow, Green },
            new[] { Yellow, Yellow, Yellow, Yellow, Green },
            new[] { Yellow, Yellow, Yellow, Yellow, Green },
            new[] { Yellow, Yellow, Yellow, Green, Green },
            new[] { Yellow, Yellow, Green, Green, Green },
            new[] { Yellow, Green, Yellow, Green, Green },
            new[] { Yellow, Yellow, Green, Green, Green },
        };

        // Act & Assert
        IsWordleNightmare(lines).ShouldBeFalse();
    }
    
    [Fact]
    public void ShouldReturnFalseIfNoLines()
    {
        // Arrange
        string[][] lines = Array.Empty<string[]>();

        // Act & Assert
        IsWordleNightmare(lines).ShouldBeFalse();
    }
    
    [Fact]
    public void ShouldReturnFalseIfOnlyOneLine()
    {
        // Arrange
        var lines = new []
        {
            new[] { Yellow, Yellow, Yellow, Yellow, Green }
        };

        // Act & Assert
        IsWordleNightmare(lines).ShouldBeFalse();
    }
    
     
    [Fact]
    public void ShouldReturnFalseIfLinesHaveIncorrectNumberOfElements()
    {
        // Arrange
        var lines = new []
        {
            new[] { Yellow, Yellow, Yellow, Yellow, Yellow },
            new[] { Yellow, Yellow, Yellow, Yellow, Green },
            new[] { Yellow, Yellow, Yellow, Green, Green, Yellow },
            new[] { Yellow, Yellow, Green, Green, Green },
            new[] { Yellow, Yellow, Green, Green, Green },
            new[] { Yellow, Yellow, Green, Green, Green },
        };

        // Act & Assert
        IsWordleNightmare(lines).ShouldBeFalse();
    }
}