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

        [Given(@"'(.*)' plays rock")]
        public void GivenPlaysRock(string playerName)
        {
            PlayerName = playerName;
            PlayerWeapon = "rock";
        }

        [Given(@"the computer will play scissors")]
        public void GivenTheComputerWillPayScissors()
        {
            ComputerWeapon = "scissors";
        }

        [When(@"we show weapon")]
        public void WhenWeShowWeapon()
        {
            
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

    }
}
