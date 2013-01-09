using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.ViewModels;

namespace WebSite.Controllers
{
    public class RockPaperScissorsController : Controller
    {
        public ActionResult GameBoard()
        {
            var viewModel = new GameBoardViewModel();
            return View(viewModel);
        }

    }
}
