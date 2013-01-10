using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using WebSite.Models;

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

        private WinGame WinResult { get { return Result as WinGame; } }
        private DrawnGame DrawResult { get { return Result as DrawnGame; } }

        [StepArgumentTransformation("(.*)")]
        public Weapon Translate(string weaponName)
        {
            switch (weaponName)
            {
                case "paper":
                    return Weapon.paper;
                case "scissors":
                    return Weapon.scissors;
                case "rock":
                    return Weapon.rock;
                default:
                    throw new ArgumentException();
            }
        }

        [Given(@"'(.*)' plays '(.*)'")]
        public void GivenPlaysRock(string playerName, Weapon weaponType)
        {
            PlayerMove = new Move() {PlayerName = playerName, WeaponType = weaponType};
        }

        [Given(@"the computer will play '(.*)'")]
        public void GivenTheComputerWillPayScissors(Weapon weaponType)
        {
            ComputerMove = new Move() { PlayerName = "Computer", WeaponType = weaponType };
        }

        [When(@"we show weapon")]
        public void WhenWeShowWeapon()
        {
            var systemUnderTest = new GameResolver();
            Result = systemUnderTest.ResolveGame(PlayerMove, ComputerMove);
        }

        [Then(@"'(.*)' wins")]
        public void PlayerWins(string playerName)
        {
            Assert.That(WinResult.WinningMove.PlayerName, Is.EqualTo(playerName));
        }

        [Then(@"'(.*)' loses")]
        public void PlayerLoses(string playerName)
        {
            Assert.That(WinResult.LosingMove.PlayerName, Is.EqualTo(playerName));
        }

        [Then(@"the outcome is described as '(.*)'")]
        public void ThenTheOutcomeIsDescribedAs(string outcomeText)
        {
            Assert.That(Result.ResultSummary, Is.EqualTo(outcomeText));
        }

        [Then(@"there is a draw")]
        public void ThenThereIsADraw()
        {
            Assert.That(DrawResult, Is.Not.Null);
        }


    }
}
