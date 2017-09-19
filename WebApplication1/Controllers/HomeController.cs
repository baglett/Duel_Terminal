using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Duel()
        {
            return View();
        }
        public ActionResult Search()
        {
			
            return View();
        }
        public ActionResult MyCollection()
        {
            return View();
        }
        public ActionResult DeckEditor()
        {
            return View();
        }
        public ActionResult MyAccount()
        {
            return View();
        }
        public ActionResult CreateMatch()
        {
            return View();
        }
        public ActionResult JoinMatch()
        {
            return View();
        }
        public ActionResult FindFriends()
        {
            return View();
        }
        public ActionResult DuelField()
        {
            return View();
        }
		public void UpdateDataBase()
		{

		}
    }
}