using System;
using WebSite.ViewModels;

namespace WebSite.Models
{
    public interface IRockPaperScissorsGameService
    {
        GameBoardViewModel PlayGame(Move playerMove);
    }
    public class RockPaperScissorsGameService : IRockPaperScissorsGameService
    {
        private readonly IGameResolver _gameResolver;
        private readonly IComputerMoveGenerator _computerMoveGenerator;

        public RockPaperScissorsGameService(IComputerMoveGenerator computerMoveGenerator, IGameResolver gameResolver)
        {
            _computerMoveGenerator = computerMoveGenerator;
            _gameResolver = gameResolver;
        }

        public GameBoardViewModel PlayGame(Move playerMove)
        {
            var generatedMove = _computerMoveGenerator.GenerateComputerMove();

            var result = _gameResolver.ResolveGame(playerMove, generatedMove);
            
            if (result.IsDraw)
            {
                return GameBoardViewModel.ShowAsDraw(result.ResultSummary);
            }
            return new GameBoardViewModel(result.WinningMove, result.LosingMove, result.ResultSummary);
        }
    }

    public class ComputerMoveGenerator : IComputerMoveGenerator
    {
        public Move GenerateComputerMove()
        {
            var randomNumberGenerator = new Random();
            var weaponIndex = randomNumberGenerator.Next(1, 3);

            var weapon = (Weapon) weaponIndex;

            return new Move() {PlayerName = "Computer", WeaponType = weapon};
        }
    }
}