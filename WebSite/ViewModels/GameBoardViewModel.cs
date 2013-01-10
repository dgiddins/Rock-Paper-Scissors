using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSite.Models;

namespace WebSite.ViewModels
{
    public class GameBoardViewModel
    {
        public GameBoardViewModel(Move winnerMove, Move losingMove, string resultText)
        {
            WinnerMove = winnerMove;
            LosingMove = losingMove;
            ResultText = resultText;
        }

        public static GameBoardViewModel ShowAsDraw(string resultText)
        {
            var viewModel = new GameBoardViewModel(null, null, resultText);
            viewModel.IsDraw = true;
            return viewModel;
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