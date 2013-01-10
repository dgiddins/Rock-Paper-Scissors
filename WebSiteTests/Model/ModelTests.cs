using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WebSite.ViewModels;
using WebSiteTests.Features.Steps;

namespace WebSiteTests.Model
{
    [TestFixture]
    public class GameServiceTests
    {
        [Test]
        public void GameServiceCallMoveGeneratorWhenPlayingAgainstComputer()
        {
            var classUnderTest = new RockPaperScissorsGameService(this);

            classUnderTest.PlayGame(new Move());

            Assert.That(_moveGeneratorCalled, Is.True);
        }

        [Test]
        public void GameServiceAlwaysReturnsStateOfBoardAfterPlay()
        {
            var classUnderTest = new RockPaperScissorsGameService(this);

            var result = classUnderTest.PlayGame(new Move());

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void GameServicePassesMoveFromPlayerToGameResolver()
        {
            var playerMove = new Move();

            var classUnderTest = new RockPaperScissorsGameService(this);

            classUnderTest.PlayGame(playerMove);

            Assert.That(_move1PassedToResolver, Is.SameAs(playerMove));
        }

        private bool _moveGeneratorCalled;
        public Move GenerateComputerMove()
        {
            _moveGeneratorCalled = true;
            return new Move();
        }

        private Move _move1PassedToResolver;
        private Move _move2PassedToResolver;
        public void ResolveGame(Move move1, Move move2)
        {
            _move1PassedToResolver = move1;
            _move2PassedToResolver = move2;
        }
    }

    public class RockPaperScissorsGameService
    {
        private readonly GameServiceTests _gameServiceTests;

        public RockPaperScissorsGameService(GameServiceTests gameServiceTests)
        {
            _gameServiceTests = gameServiceTests;
        }

        public GameBoardViewModel PlayGame(Move playerMove)
        {
            _gameServiceTests.ResolveGame(playerMove, null);

            _gameServiceTests.GenerateComputerMove();
            return new GameBoardViewModel();
        }
    }
}
