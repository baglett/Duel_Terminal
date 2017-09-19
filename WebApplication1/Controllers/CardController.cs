using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuelTerminal.Models;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace WebApplication1.Controllers
{
    public class CardController : Controller
    {
        // GET: Card
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult UpdateDataBase()
		{
			SqlCommand cmd;
			SqlConnection con;
			//SqlDataAdapter da;

			con = new SqlConnection(@"Data Source=BAR-JKPTPC2\SQLEXPRESS;Initial Catalog=CardDb;Integrated Security=True");
			con.Open();
			
			//access excel sheet of card names 
			Excel.Application xlApp = new Excel.Application();
			Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\jaredb\OneDrive\Documents\Duel Terminal Project\yugiohdatabase.xlsx");
			Excel._Worksheet xlWorksheet = (Excel._Worksheet)xlWorkbook.Sheets[1];
			Excel.Range xlRange = xlWorksheet.UsedRange;

			int rowCount = xlRange.Rows.Count;

			for (int i = 1; i <= rowCount; i++)//for each name in list
			{
				//if card exists in DB then next card 
				//else create card with name
				Card newCard = new Card(xlRange.Cells[1,i].Value.ToString());
				Console.Write(newCard.Name);
				Console.Write(newCard.Status);
				Console.Write(newCard.Text);
				Console.Write(newCard.Type);
				Console.Write(newCard.CardType);
				Console.Write(newCard.Attack);
				Console.Write(newCard.Defense);
				Console.Write(newCard.Attribute);
				Console.Write(newCard.Level);
				//add to database
				cmd = new SqlCommand("INSERT INTO Cards (Name,Status,Text,CardType,Type,Attribute,Attack,Defense,Lv,Image,Image_Url) VALUES (@Name, @Status, @Text, @CardType, @Type, @Attribute, @Attack, @Defense, @Lv, @Image, @Image_Url)", con);
				cmd.Parameters.AddWithValue("@Name", newCard.Name);
				cmd.Parameters.AddWithValue("@Status", newCard.Status);
				cmd.Parameters.AddWithValue("@Text", newCard.Text);
				cmd.Parameters.AddWithValue("@CardType", newCard.CardType);
				cmd.Parameters.AddWithValue("@Type", newCard.Type);
				cmd.Parameters.AddWithValue("@Attribute", newCard.Attribute);
				cmd.Parameters.AddWithValue("@Attack", newCard.Attack);
				cmd.Parameters.AddWithValue("@Defense", newCard.Defense);
				cmd.Parameters.AddWithValue("@Lv", newCard.Level);
				cmd.Parameters.AddWithValue("@Image", newCard.Image);
				cmd.Parameters.AddWithValue("@Image_Url", newCard.ImageUrl);
				cmd.ExecuteNonQuery();
			}
		


			return View();
		}
    }
}