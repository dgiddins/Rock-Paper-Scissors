using NUnit.Framework;
using TechTalk.SpecFlow;

namespace WebSiteTests.Features.Steps
{
    [Binding]
    public class GamePlaySteps
    {
        private Move PlayerMove
        {
            get { return ScenarioContext.Current["PlayerMove"] as Move; }
            set { ScenarioContext.Current["PlayerMove"] = value; }
        }
        private Move ComputerMove
        {
            get { return ScenarioContext.Current["ComputerMove"] as Move; }
            set { ScenarioContext.Current["ComputerMove"] = value; }
        }
        private GameResult Result
        {
            get { return ScenarioContext.Current["Result"] as GameResult; }
            set { ScenarioContext.Current["Result"] = value;}
        }

        [Given(@"'(.*)' plays '(.*)'")]
        public void GivenPlaysRock(string playerName, string weaponName)
        {
            PlayerMove = new Move() {PlayerName = playerName, WeaponName = weaponName};
        }

        [Given(@"the computer will play '(.*)'")]
        public void GivenTheComputerWillPayScissors(string weaponName)
        {
            ComputerMove = new Move() { PlayerName = "Computer", WeaponName = weaponName };
        }

        [When(@"we show weapon")]
        public void WhenWeShowWeapon()
        {
            var systemUnderTest = new GameResolver();
            Result = systemUnderTest.GetResult(PlayerMove, ComputerMove);
        }

        [Then(@"'(.*)' wins")]
        public void PlayerWins(string playerName)
        {
            Assert.That(Result.WinningMove.PlayerName, Is.EqualTo(playerName));
        }

        [Then(@"the outcome is described as '(.*)'")]
        public void ThenTheOutcomeIsDescribedAs(string outcomeText)
        {
            Assert.That(Result.ResultSummary, Is.EqualTo(outcomeText));
        }

        [Then(@"there is a draw")]
        public void ThenThereIsADraw()
        {
            Assert.That(Result.IsDraw, Is.True);
        }


    }

    public class GameResolver
    {
        public GameResult GetResult(Move move1, Move move2)
        {
            var result = new GameResult();

            var winningMove = GetWinningMove(move1, move2);
            var lossingMove = GetLosingMove(move1, move2, winningMove);

            if (winningMove == null)
            {
                result.IsDraw = true;
                result.ResultSummary = "Draw, what are the odds!";
            }
            else
            {
                result.WinningMove = winningMove;
                result.ResultSummary = string.Format("{0} beats {1}, {2} wins!", winningMove.WeaponName, lossingMove.WeaponName,
                                              winningMove.PlayerName);
            }

            return result;
        }

        private static Move GetLosingMove(Move move1, Move move2, Move winningMove)
        {
            var lossingMove = winningMove != move1 ? move1 : move2;
            return lossingMove;
        }

        private Move GetWinningMove(Move move1, Move move2)
        {
            if (move1.WeaponName == move2.WeaponName)
                return null;
            if ((move1.WeaponName == "rock" && move2.WeaponName == "paper")
                || (move1.WeaponName == "paper" && move2.WeaponName == "scissors")
                || (move1.WeaponName == "scissors" && move2.WeaponName == "rock"))
                return move2;
            else
            {
                return move1;
            }
        }
    }

    public class GameResult
    {
        public bool IsDraw { get; set; }
        public Move WinningMove { get; set; }
        public string ResultSummary { get; set; }
    }

    public class Move
    {
        public string PlayerName { get; set; }
        public string WeaponName { get; set; }
    }

   
}
