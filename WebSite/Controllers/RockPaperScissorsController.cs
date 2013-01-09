using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers
{
    public class RockPaperScissorsController : Controller
    {
        public ActionResult GameBoard()
        {
            return View();
        }

    }
}
