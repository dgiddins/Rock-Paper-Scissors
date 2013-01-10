namespace WebSite.Models
{
    public class GameResolver : IGameResolver
    {
        public GameResult ResolveGame(Move move1, Move move2)
        {
            var winningMove = GetWinningMove(move1, move2);
            var lossingMove = GetLosingMove(move1, move2, winningMove);

            if (IsResultADraw(winningMove))
            {
                return new DrawnGame("Draw, what are the odds!");
                
            }
            else
            {
                return new WinGame(winningMove, lossingMove, GenerateResultSummaryMessage(winningMove, lossingMove));
            }
        }

        private static string GenerateResultSummaryMessage(Move winningMove, Move lossingMove)
        {
            return string.Format("{0} beats {1}, {2} wins!", winningMove.WeaponType, lossingMove.WeaponType,
                                 winningMove.PlayerName);
        }

        private static bool IsResultADraw(Move winningMove)
        {
            return winningMove == null;
        }

        private static Move GetLosingMove(Move move1, Move move2, Move winningMove)
        {
            var lossingMove = winningMove != move1 ? move1 : move2;
            return lossingMove;
        }

        private Move GetWinningMove(Move move1, Move move2)
        {
            if (move1.WeaponType == move2.WeaponType)
                return null;
            if ((move1.WeaponType == Weapon.rock && move2.WeaponType == Weapon.paper)
                || (move1.WeaponType == Weapon.paper && move2.WeaponType == Weapon.scissors)
                || (move1.WeaponType == Weapon.scissors && move2.WeaponType == Weapon.rock))
                return move2;
            else
            {
                return move1;
            }
        }
    }
}