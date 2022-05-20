using System.Collections.Generic;
using BowlingKata_TDD;
using NUnit.Framework;

namespace BowlingGameTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        //Arrange
        var game = new BowlingGame("X X");
        //Act
        var expected = "X X";
        //Asser
        Assert.AreEqual(expected,game.rawScore);
    }
    
  
    [Test]
    public void Conversion_Should_Return_Collect_Value()
    {
        var game = new BowlingGame("3/ 8/");
        
        var expected = new List<int>() { 3,7,8,2 };
        
        Assert.AreEqual(expected,game.Conversion());
    }
    
    [Test]
    public void FinalScore_Should_Return_Correct_Value_For_All_Strike()
    {
        var game = new BowlingGame("X X X X X X X X X X X X");

        var expected = 300;
        
        Assert.AreEqual(expected,game.FinalScore(game.Conversion()));
    }

    [Test]
    public void FinalScore_Should_Return_Correct_Value_For_Missed()
    {
        
        var game = new BowlingGame("9- 9- 9- 9- 9- 9- 9- 9- 9- 9-");

        var expected = 90;
        
        Assert.AreEqual(expected,game.FinalScore(game.Conversion()));
    }
    [Test]
    public void FinalScore_Should_Return_Correct_Value_For_All_Spare()
    {
        
        var game = new BowlingGame("8/ 5/ 4/ 7/ 5/ 5/ 3/ 9/ 5/ 5/5");

        var expected = 153;
        
        Assert.AreEqual(expected,game.FinalScore(game.Conversion()));
    }
    [Test]
    public void FinalScore_Should_Return_Correct_Value_For_Other_Possible_Scores()
    {
        
        var game = new BowlingGame("45 54 36 27 -9 63 81 18 9- 7/ 5");

        var expected = 96;
        
        Assert.AreEqual(expected,game.FinalScore(game.Conversion()));
    }
    [Test]
    public void FinalScore_Should_Return_Correct_Value_For_Sprike()
    {
        
        var game = new BowlingGame("12 34 0/ 0/ X X 00 18 72 X 0/");

        var expected = 108;
        
        Assert.AreEqual(expected,game.FinalScore(game.Conversion()));
    }

    
}