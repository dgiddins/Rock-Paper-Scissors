using System.Web.Mvc;
using NUnit.Framework;
using WebSite.Controllers;
using WebSite.Models;
using WebSite.ViewModels;

namespace WebSiteTests.Controllers
{
    [TestFixture]
    public class RockPaperScissorsControllerTests : IRockPaperScissorsGameService
    {
        private RockPaperScissorsController BuildUpClassUnderTest()
        {
            var mockedGameService = this as IRockPaperScissorsGameService;
            var classUnderTest = new RockPaperScissorsController(mockedGameService);

            return classUnderTest;
        }

        [Test]
        public void WhenGameBoardLoadedResultSectionIsBlank()
        {
            var classUnderTest = BuildUpClassUnderTest();

            var viewModel = classUnderTest.GameBoard() as ViewResult;

            var result = viewModel.Model as GameBoardViewModel;

            Assert.That(result.WinnerText, Is.Null);
            Assert.That(result.WinnerImage, Is.Null);
            Assert.That(result.LoserText, Is.Null);
            Assert.That(result.LoserImage, Is.Null);
            Assert.That(result.ResultText, Is.Null);
        }

        [Test]
        public void ControllerPassesMoveDetailsToGameServiceWhenPlayingRock()
        {
            var classUnderTest = BuildUpClassUnderTest();

            classUnderTest.PlayRock();
            
            Assert.That(_movedPassedToGameService, Is.Not.Null);
            Assert.That(_movedPassedToGameService.WeaponType, Is.EqualTo(Weapon.rock));
            Assert.That(_movedPassedToGameService.PlayerName, Is.EqualTo("Player1"));
        }

        [Test]
        public void ControllerSetsModelToBeResultOfGameService()
        {
            _responseFromGameService = new GameBoardViewModel();

            var classUnderTest = BuildUpClassUnderTest();

            var viewResult = classUnderTest.PlayRock() as ViewResult;

            Assert.That(viewResult.Model, Is.SameAs(_responseFromGameService));
        }

        private Move _movedPassedToGameService;
        private GameBoardViewModel _responseFromGameService;
        public GameBoardViewModel PlayGame(Move playerMove)
        {
            _movedPassedToGameService = playerMove;
            return _responseFromGameService;
        }

        [Test]
        public void WhenPlayerPlaysPaperResultSectionIsUpdatedWithAResult()
        {
            var classUnderTest = BuildUpClassUnderTest();

            var viewModel = classUnderTest.PlayPaper() as ViewResult;

            var result = viewModel.Model as GameBoardViewModel;

            Assert.That(result.LoserText, Is.EqualTo("Player 1"));
            Assert.That(result.LoserImage, Is.EqualTo("/Images/paper.png"));
            Assert.That(result.WinnerText, Is.EqualTo("Computer"));
            Assert.That(result.WinnerImage, Is.EqualTo("/Images/scissors.png"));
            Assert.That(result.ResultText, Is.EqualTo("Scissors beats paper, Computer wins!"));
        }

        [Test]
        public void WhenPlayerPlaysScissorsResultSectionIsUpdatedWithAResult()
        {
            var classUnderTest = BuildUpClassUnderTest();

            var viewModel = classUnderTest.PlayScissors() as ViewResult;

            var result = viewModel.Model as GameBoardViewModel;

            Assert.That(result.WinnerText, Is.EqualTo("Player 1"));
            Assert.That(result.WinnerImage, Is.EqualTo("/Images/scissors.png"));
            Assert.That(result.LoserText, Is.EqualTo("Computer"));
            Assert.That(result.LoserImage, Is.EqualTo("/Images/scissors.png"));
            Assert.That(result.ResultText, Is.EqualTo("Draw - what are the chances"));
        }
    }
}
