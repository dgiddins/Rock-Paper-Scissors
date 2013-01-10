namespace WebSite.Models
{
    public class GameResult
    {
        public bool IsDraw { get; set; }
        public Move WinningMove { get; set; }
        public string ResultSummary { get; set; }
    }
}