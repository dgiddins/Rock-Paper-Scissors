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
            var viewModel = new GameBoardViewModel(null);
            return View(viewModel);
        }

        public ActionResult PlayRock()
        {
            var move = GenerateMove(Weapon.rock);
            var viewModel = _gameService.PlayGame(move);

            return GameBoardView(viewModel);
        }

        public ActionResult PlayPaper()
        {
            var move = GenerateMove(Weapon.paper);
            var viewModel = _gameService.PlayGame(move);

            return GameBoardView(viewModel);
        }

        public ActionResult PlayScissors()
        {
            var move = GenerateMove(Weapon.scissors);
            var viewModel = _gameService.PlayGame(move);

            return GameBoardView(viewModel);
        }

        private ViewResult GameBoardView(GameBoardViewModel viewModel)
        {
            return View("GameBoard", viewModel);
        }

        private Move GenerateMove(Weapon weaponType)
        {
            var move = new Move() { PlayerName = "Player1", WeaponType = weaponType};
            return move;
        }
    }
}
