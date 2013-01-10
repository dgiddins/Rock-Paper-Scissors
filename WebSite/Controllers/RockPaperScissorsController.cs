using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;
using WebSite.ViewModels;

namespace WebSite.Controllers
{
    public class RockPaperScissorsController : Controller
    {
        private readonly IRockPaperScissorsGameService _gameService;

        public RockPaperScissorsController(IRockPaperScissorsGameService gameService)
        {
            _gameService = gameService;
        }

        public ActionResult GameBoard()
        {
            var viewModel = new GameBoardViewModel();
            return View(viewModel);
        }

        public ActionResult PlayRock()
        {
            var move = new Move() {PlayerName = "Player1", WeaponType = Weapon.rock};
            var viewModel = _gameService.PlayGame(move);

            return View("GameBoard", viewModel);
        }

        public ActionResult PlayPaper()
        {
            var viewModel = new GameBoardViewModel();
            viewModel.LoserText = "Player 1";
            viewModel.LoserImage = "/Images/paper.png";
            viewModel.WinnerText = "Computer";
            viewModel.WinnerImage = "/Images/scissors.png";
            viewModel.ResultText = "Scissors beats paper, Computer wins!";

            return View("GameBoard", viewModel);
        }

        public ActionResult PlayScissors()
        {
            //Some refinmen around rendering of draw required here....

            var viewModel = new GameBoardViewModel();
            viewModel.WinnerText = "Player 1";
            viewModel.WinnerImage = "/Images/scissors.png";
            viewModel.LoserText = "Computer";
            viewModel.LoserImage = "/Images/scissors.png";
            viewModel.ResultText = "Draw - what are the chances";

            return View("GameBoard", viewModel);
        }
    }
}
