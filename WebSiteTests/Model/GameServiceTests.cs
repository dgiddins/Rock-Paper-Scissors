using NUnit.Framework;
using WebSite;
using WebSite.Models;
using WebSiteTests.Features.Steps;

namespace WebSiteTests.Model
{
    [TestFixture]
    public class GameServiceTests : IComputerMoveGenerator, IGameResolver
    {
        private RockPaperScissorsGameService BuildUpClassUnderTest()
        {
            var mockedGameResolver = this as IGameResolver;
            var mockedComputerMoveGenerator = this as IComputerMoveGenerator;

            return new RockPaperScissorsGameService(mockedComputerMoveGenerator, mockedGameResolver);
        }

        [Test]
        public void GameServiceCallMoveGeneratorWhenPlayingAgainstComputer()
        {
            var classUnderTest = BuildUpClassUnderTest();

            classUnderTest.PlayGame(new Move());

            Assert.That(_moveGeneratorCalled, Is.True);
        }

        [Test]
        public void GameServiceAlwaysReturnsStateOfBoardAfterPlay()
        {
            var classUnderTest = BuildUpClassUnderTest();

            var result = classUnderTest.PlayGame(new Move());
            
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void GameServicePassesMoveFromPlayerToGameResolver()
        {
            var playerMove = new Move();

            var classUnderTest = BuildUpClassUnderTest();

            classUnderTest.PlayGame(playerMove);

            Assert.That(_move1PassedToResolver, Is.SameAs(playerMove));
        }

        [Test]
        public void GameServicePassesMoveFromMoveGeneratorToGameResolver()
        {
            _moveToReturnFromMoveGenerator = new Move();

            var classUnderTest = BuildUpClassUnderTest();

            classUnderTest.PlayGame(new Move());

            Assert.That(_move2PassedToResolver, Is.SameAs(_moveToReturnFromMoveGenerator));
        }

        private bool _moveGeneratorCalled;
        private Move _moveToReturnFromMoveGenerator;
        public Move GenerateComputerMove()
        {
            _moveGeneratorCalled = true;
            return _moveToReturnFromMoveGenerator;
        }

        private Move _move1PassedToResolver;
        private Move _move2PassedToResolver;
        public GameResult ResolveGame(Move move1, Move move2)
        {
            _move1PassedToResolver = move1;
            _move2PassedToResolver = move2;
            return null;
        }
    }
}
