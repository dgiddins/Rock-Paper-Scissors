using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.ViewModels
{
    public class GameBoardViewModel
    {
        public string WinnerText { get; set; }
        public string WinnerImage { get; set; }
        public string LoserText { get; set; }
        public string LoserImage { get; set; }
        public string ResultText { get; set; }
    }
}