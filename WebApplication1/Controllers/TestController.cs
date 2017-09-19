using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuelTerminal.Models;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        public String Index()
        {
			Card test = new Card("Trap Hole");
			return test.Status + System.Environment.NewLine + test.Name + System.Environment.NewLine + test.Text + System.Environment.NewLine + test.CardType + System.Environment.NewLine + test.Type + System.Environment.NewLine + test.Attribute + System.Environment.NewLine + test.Attack + System.Environment.NewLine + test.Defense + System.Environment.NewLine + test.Level + System.Environment.NewLine + test.Property;
			//return test.UrlString;
        }

		public ActionResult Test1()
		{
			return View();
		}
	}
}