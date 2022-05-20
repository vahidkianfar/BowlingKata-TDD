using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace BowlingKata_TDD;

public class BowlingGame
{
    public string rawScore { get; set; }
    public BowlingGame(string input) => rawScore = input;

    public List<int> Conversion()
    {
        rawScore = Regex.Replace(rawScore, @"\s", String.Empty);
        var intScore = new List<int>();
        foreach (var score in rawScore)
        {
            if(score=='X') intScore.Add(10);
            if(score=='-') intScore.Add(0);
            if(score=='/') intScore.Add(10-intScore[^1]);
            else
            {
                if(int.TryParse(score.ToString(),out var addNumber))
                    intScore.Add(addNumber);
            }
        }
        return intScore;
    }
    public int FinalScore(List<int> intScores)
    {
        int sum = 0;
        for (int counter = 0; counter + 1 < intScores.Count; counter += 2)
        {
            //if it's an OpenFrame.
            if (intScores[counter] + intScores[counter + 1] < 10)
            {
                sum += intScores[counter] + intScores[counter + 1];
                continue;
            }
            
            if (counter + 2 >= intScores.Count) 
                break;
            
            //Bonus Round
            sum += intScores[counter] + intScores[counter + 1] + intScores[counter + 2];
            
            //because of Strike or Spare, we need to wait for the next round
            if (intScores[counter] == 10)
                counter--;
        }
        return sum;
    }
}