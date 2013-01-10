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

            Assert.That(result.ResultText, Is.Null);
            Assert.That(result.WinnerMove, Is.Null);
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
        public void ControllerPassesMoveDetailsToGameServiceWhenPlayingPaper()
        {
            var classUnderTest = BuildUpClassUnderTest();

            classUnderTest.PlayPaper();

            Assert.That(_movedPassedToGameService, Is.Not.Null);
            Assert.That(_movedPassedToGameService.WeaponType, Is.EqualTo(Weapon.paper));
            Assert.That(_movedPassedToGameService.PlayerName, Is.EqualTo("Player1"));
        }
        
        [Test]
        public void ControllerPassesMoveDetailsToGameServiceWhenPlayingScissors()
        {
            var classUnderTest = BuildUpClassUnderTest();

            classUnderTest.PlayScissors();

            Assert.That(_movedPassedToGameService, Is.Not.Null);
            Assert.That(_movedPassedToGameService.WeaponType, Is.EqualTo(Weapon.scissors));
            Assert.That(_movedPassedToGameService.PlayerName, Is.EqualTo("Player1"));
        }

        [Test]
        public void ControllerSetsModelToBeResultOfGameServiceOnPlayRock()
        {
            _responseFromGameService = new GameBoardViewModel(null);

            var classUnderTest = BuildUpClassUnderTest();

            var viewResult = classUnderTest.PlayRock() as ViewResult;

            Assert.That(viewResult.Model, Is.SameAs(_responseFromGameService));
        }

        [Test]
        public void ControllerSetsModelToBeResultOfGameServiceOnPlayScissors()
        {
            _responseFromGameService = new GameBoardViewModel(null);

            var classUnderTest = BuildUpClassUnderTest();

            var viewResult = classUnderTest.PlayScissors() as ViewResult;

            Assert.That(viewResult.Model, Is.SameAs(_responseFromGameService));
        }

        [Test]
        public void ControllerSetsModelToBeResultOfGameServiceOnPlayPaper()
        {
            _responseFromGameService = new GameBoardViewModel(null);

            var classUnderTest = BuildUpClassUnderTest();

            var viewResult = classUnderTest.PlayPaper() as ViewResult;

            Assert.That(viewResult.Model, Is.SameAs(_responseFromGameService));
        }

        private Move _movedPassedToGameService;
        private GameBoardViewModel _responseFromGameService;
        public GameBoardViewModel PlayGame(Move playerMove)
        {
            _movedPassedToGameService = playerMove;
            return _responseFromGameService;
        }
    }
}
