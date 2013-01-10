using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
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

        private bool _moveGeneratorCalled;
        public Move GenerateComputerMove()
        {
            _moveGeneratorCalled = true;
            return new Move();
        }
    }

    public class RockPaperScissorsGameService
    {
        private readonly GameServiceTests _gameServiceTests;

        public RockPaperScissorsGameService(GameServiceTests gameServiceTests)
        {
            _gameServiceTests = gameServiceTests;
        }

        public void PlayGame(Move playerMove)
        {
            _gameServiceTests.GenerateComputerMove();
        }
    }
}
