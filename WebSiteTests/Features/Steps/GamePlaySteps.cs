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
            PlayerName = playerName;
            PlayerWeapon = weaponName;
        }

        [Given(@"the computer will play '(.*)'")]
        public void GivenTheComputerWillPayScissors(string weaponName)
        {
            ComputerWeapon = weaponName;
        }

        [When(@"we show weapon")]
        public void WhenWeShowWeapon()
        {
            if (PlayerWeapon == "rock" && ComputerWeapon == "scissors")
            {
                WinnerName = PlayerName;
                ResultSummary = "rock beats scissors, Player1 wins!";
            }
            else if (PlayerWeapon == "rock" && ComputerWeapon == "paper")
            {
                WinnerName = "Computer";
                ResultSummary = "paper beats rock, Computer wins!";
            }
            else if (PlayerWeapon == "scissors" && ComputerWeapon == "paper")
            {
                WinnerName = "Player1";
                ResultSummary = "scissors beats paper, Player1 wins!";
            }
            else if (PlayerWeapon == "scissors" && ComputerWeapon == "rock")
            {
                WinnerName = "Computer";
                ResultSummary = "rock beats scissors, Computer wins!";
            }
            else if (PlayerWeapon == "paper" && ComputerWeapon == "rock")
            {
                WinnerName = "Player1";
                ResultSummary = "paper beats rock, Player1 wins!";
            }
            else if (PlayerWeapon == "paper" && ComputerWeapon == "scissors")
            {
                WinnerName = "Computer";
                ResultSummary = "scissors beats paper, Computer wins!";
            }
            else if (PlayerWeapon == ComputerWeapon)
            {
                IsDraw = true;
                ResultSummary = "Draw, what are the odds!";
            }

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
}
