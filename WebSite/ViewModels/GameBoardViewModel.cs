using WebSite.Models;

namespace WebSite.ViewModels
{
    public class GameBoardViewModel
    {
        public GameBoardViewModel(GameResult gameResult)
        {
            if (gameResult is WinGame)
            {
                var winGame = gameResult as WinGame;
                WinnerMove = winGame.WinningMove;
                LosingMove = winGame.LosingMove;
                IsDraw = false;
            }
            if (gameResult is DrawnGame)
            {
                IsDraw = true;
            }
            if (gameResult != null)
                ResultText = gameResult.ResultSummary;
        }
        
        public Move WinnerMove { get; private set; }
        public Move LosingMove { get; private set; }
        public string ResultText { get; private set; }
        public bool IsDraw { get; private set; }

        public Weapon Rock { get {return Weapon.rock;}}
        public Weapon Paper { get {return Weapon.paper;}}
        public Weapon Scissors { get { return Weapon.scissors;}}
    }
}