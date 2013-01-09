using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }
    }
}
