using NUnit.Framework;
using WebSite.Models;
using WebSite.ViewModels;

namespace WebSiteTests.ViewModels
{
    [TestFixture]
    public class GameBoardViewModelTests
    {
        [Test]
        public void BuildsCorrectlyFromAWinGame()
        {
            var winninMove = new Move();
            var losingMove = new Move();
            const string winSummary = "Win";

            var result = new WinGame(winninMove, losingMove, winSummary);

            var classUnderTest = new GameBoardViewModel(result);

            Assert.That(classUnderTest.WinnerMove, Is.SameAs(winninMove));
            Assert.That(classUnderTest.LosingMove, Is.SameAs(losingMove));
            Assert.That(classUnderTest.ResultText, Is.EqualTo(winSummary));
            Assert.That(classUnderTest.IsDraw, Is.False);
        }

        [Test]
        public void BuildsCorrectlyFromADrawnGame()
        {
            const string drawText = "draw";

            var result = new DrawnGame(drawText);

            var classUnderTest = new GameBoardViewModel(result);

            Assert.That(classUnderTest.WinnerMove, Is.Null);
            Assert.That(classUnderTest.LosingMove, Is.Null);
            Assert.That(classUnderTest.ResultText, Is.EqualTo(drawText));
            Assert.That(classUnderTest.IsDraw, Is.True);
        }

    }
}
