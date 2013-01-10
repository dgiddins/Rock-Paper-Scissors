namespace WebSite.Models
{
    public abstract class GameResult
    {
        protected GameResult(string summary)
        {
            ResultSummary = summary;
        }
        public string ResultSummary { get; private set; }
    }

    public class DrawnGame : GameResult
    {
        public DrawnGame(string summary)
            : base(summary)
        {
        }
    }

    public class WinGame : GameResult
    {
        public WinGame(Move winningMove, Move losingMove, string summary)
            :base(summary)
        {
            WinningMove = winningMove;
            LosingMove = losingMove;
        }

        public Move WinningMove { get; private set; }
        public Move LosingMove { get; private set; }
    }
}