using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace WebSiteTests.Features.Steps
{
    [Binding]
    public class GamePlaySteps
    {
        public Move PlayerMove
        {
            get { return ScenarioContext.Current["PlayerMove"] as Move; }
            set { ScenarioContext.Current["PlayerMove"] = value; }
        }
        public Move ComputerMove
        {
            get { return ScenarioContext.Current["ComputerMove"] as Move; }
            set { ScenarioContext.Current["ComputerMove"] = value; }
        }

        public string PlayerName
        {
            get { return ScenarioContext.Current["PlayerName"] as string; }
            set { ScenarioContext.Current["PlayerName"] = value; } 
        }
        public string PlayerWeapon
        {
            get { return ScenarioContext.Current["PlayerWeapon"] as string; }
            set { ScenarioContext.Current["PlayerWeapon"] = value; } 
        }
        public string ComputerWeapon
        {
            get { return ScenarioContext.Current["ComputerWeapon"] as string; }
            set { ScenarioContext.Current["ComputerWeapon"] = value; } 
        }


        public string WinnerName
        {
            get { return ScenarioContext.Current["WinnerName"] as string; }
            set { ScenarioContext.Current["WinnerName"] = value; }
        }
        public string ResultSummary
        {
            get { return ScenarioContext.Current["ResultSummary"] as string; }
            set { ScenarioContext.Current["ResultSummary"] = value; }
        }
        public bool IsDraw
        {
            get { return (bool)ScenarioContext.Current["IsDraw"]; }
            set { ScenarioContext.Current["IsDraw"] = value; }
        }

        [Given(@"'(.*)' plays '(.*)'")]
        public void GivenPlaysRock(string playerName, string weaponName)
        {
            PlayerMove = new Move() {PlayerName = playerName, WeaponName = weaponName};

            PlayerName = playerName;
            PlayerWeapon = weaponName;
        }

        [Given(@"the computer will play '(.*)'")]
        public void GivenTheComputerWillPayScissors(string weaponName)
        {
            ComputerMove = new Move() { PlayerName = "Computer", WeaponName = weaponName };

            ComputerWeapon = weaponName;
        }

        [When(@"we show weapon")]
        public void WhenWeShowWeapon()
        {

            var winningMove = GetWinningMove(PlayerMove, ComputerMove);

            var lossingMove = winningMove != PlayerMove ? PlayerMove : ComputerMove;

            if (winningMove == null)
            {
                IsDraw = true;
                ResultSummary = "Draw, what are the odds!";
            }
            else
            {
                WinnerName = winningMove.PlayerName;
                ResultSummary = string.Format("{0} beats {1}, {2} wins!", winningMove.WeaponName, lossingMove.WeaponName,
                                              winningMove.PlayerName);
            }
        }
        
        private Move GetWinningMove(Move move1, Move move2)
        {
            if (move1.WeaponName == "rock" && move2.WeaponName == "paper")
                return move2;
            if (move1.WeaponName == "rock" && move2.WeaponName == "scissors")
                return move1;
            if (move1.WeaponName == "paper" && move2.WeaponName == "scissors")
                return move2;
            if (move1.WeaponName == "paper" && move2.WeaponName == "rock")
                return move1;
            if (move1.WeaponName == "scissors" && move2.WeaponName == "paper")
                return move1;
            if (move1.WeaponName == "scissors" && move2.WeaponName == "rock")
                return move2;
            if (move1.WeaponName == move2.WeaponName) ;
                return null;
        }

        [Then(@"'(.*)' wins")]
        public void PlayerWins(string playerName)
        {
            Assert.That(WinnerName, Is.EqualTo(playerName));
        }

        [Then(@"the outcome is described as '(.*)'")]
        public void ThenTheOutcomeIsDescribedAs(string outcomeText)
        {
            Assert.That(ResultSummary, Is.EqualTo(outcomeText));
        }

        [Then(@"there is a draw")]
        public void ThenThereIsADraw()
        {
            Assert.That(IsDraw, Is.True);
        }


    }

    public class Move
    {
        public string PlayerName { get; set; }
        public string WeaponName { get; set; }
    }
}
