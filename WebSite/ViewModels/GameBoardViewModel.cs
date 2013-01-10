using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSite.Models;

namespace WebSite.ViewModels
{
    public class GameBoardViewModel
    {
        public string WinnerText { get; set; }
        public string WinnerImage { get; set; }
        public string LoserText { get; set; }
        public string LoserImage { get; set; }
        public string ResultText { get; set; }

        public Weapon WinnerWeapon { get; set; }

        public Move WinnerMove { get; set; }
        public Move LosingMove { get; set; }
    }
}