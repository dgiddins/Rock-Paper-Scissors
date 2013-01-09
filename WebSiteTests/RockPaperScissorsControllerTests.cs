using System.Web.Mvc;
using NUnit.Framework;
using WebSite.Controllers;
using WebSite.ViewModels;

namespace WebSiteTests
{
    [TestFixture]
    public class RockPaperScissorsControllerTests
    {
        [Test]
        public void WhenGameBoardLoadedResultSectionIsBlank()
        {
            var classUnderTest = new RockPaperScissorsController();

            var viewModel = classUnderTest.GameBoard() as ViewResult;

            var result = viewModel.Model as GameBoardViewModel;

            Assert.That(result.WinnerText, Is.Null);
            Assert.That(result.WinnerImage, Is.Null);
            Assert.That(result.LoserText, Is.Null);
            Assert.That(result.LoserImage, Is.Null);
            Assert.That(result.ResultText, Is.Null);

        }

        [Test]
        public void WhenPlayerPlaysRockResultSectionIsUpdatedWithAResult()
        {
            var classUnderTest = new RockPaperScissorsController();

            var viewModel = classUnderTest.PlayRock() as ViewResult;

            var result = viewModel.Model as GameBoardViewModel;

            Assert.That(result.WinnerText, Is.EqualTo("Player 1"));
            Assert.That(result.WinnerImage, Is.EqualTo("/Images/rock.png"));
            Assert.That(result.LoserText, Is.EqualTo("Computer"));
            Assert.That(result.LoserImage, Is.EqualTo("/Images/scissors.png"));
            Assert.That(result.ResultText, Is.EqualTo("Stone beats scissors, Player 1 wins!"));
        }
    }
}
