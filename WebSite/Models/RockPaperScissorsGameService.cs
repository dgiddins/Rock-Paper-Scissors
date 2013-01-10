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

            _gameResolver.ResolveGame(playerMove, generatedMove);
            
            return new GameBoardViewModel();
        }
    }
}