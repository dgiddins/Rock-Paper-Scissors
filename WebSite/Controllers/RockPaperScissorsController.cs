using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.ViewModels;

namespace WebSite.Controllers
{
    public class RockPaperScissorsController : Controller
    {
        public ActionResult GameBoard()
        {
            var viewModel = new GameBoardViewModel();
            return View(viewModel);
        }

        public ActionResult PlayRock()
        {
            var viewModel = new GameBoardViewModel();
            viewModel.WinnerText = "Player 1";
            viewModel.WinnerImage = "/Images/rock.png";
            viewModel.LoserText = "Computer";
            viewModel.LoserImage = "/Images/scissors.png";
            viewModel.ResultText = "Stone beats scissors, Player 1 wins!";

            return View("GameBoard", viewModel);
        }
    }
}
