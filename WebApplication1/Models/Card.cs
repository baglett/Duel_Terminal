using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Collections;

namespace DuelTerminal.Models
{
	public class Card
	{
		public string API { get; set; }
		public string Status { get; set; }
		public string Name { get; set; }
		public string CardType { get; set; }
		public string Text { get; set; }
		public string Attribute { get; set; }
		public string Type { get; set; }
		public int Attack { get; set; }
		public int Defense { get; set; }
		public int Level { get; set; }
		public string ImageUrl { get; set; }
		public string Property { get; set; }
		public object Image { get; set; }
		


		//constructor
		public Card(string name)
		{
			//access API Data String 
			string url = "https://private-anon-6faa03cb86-yugiohprices.apiary-proxy.com/api/card_data/" + name;
			WebClient client = new WebClient();
			string urlString = client.DownloadString(url);

			//get rid of curly brackets in this string 
			urlString = ReplaceCurly(urlString);

			//split 
			ArrayList key = Split(urlString);

			//return string 
			string splitUrl = "";


			//split and remove the quotations then add into the arraylist 
		
			//assign attributes 
			if (key.Contains("status")){
				int index = key.IndexOf("status") + 1;
				this.Status = key[index].ToString();
			}

			if (key.Contains("name"))
			{
				int index = key.IndexOf("name") + 1;
				this.Name = key[index].ToString();
			}

			if (key.Contains("text"))
			{
				int index = key.IndexOf("text") + 1;
				this.Text = key[index].ToString();
			}

			if (key.Contains("card_type"))
			{
				int index = key.IndexOf("card_type") + 1;
				this.CardType = key[index].ToString();
			}

			if (key.Contains("type"))
			{
				int index = key.IndexOf("type") + 1;
				this.Type = key[index].ToString();
			}
			if (key.Contains("family"))
			{
				int index = key.IndexOf("family") + 1;
				this.Attribute = key[index].ToString();
			}

			if (key.Contains("atk") && key[key.IndexOf("atk") +1].ToString() != "null")
			{
				int index = key.IndexOf("atk") + 1;
				this.Attack = Int32.Parse(key[index].ToString());
			}
			if (key.Contains("def") && key[key.IndexOf("def") + 1].ToString() != "null")
			{
				int index = key.IndexOf("def") + 1;
				this.Defense = Int32.Parse(key[index].ToString());
			}
			if (key.Contains("level") && key[key.IndexOf("level") + 1].ToString() != "null")
			{
				int index = key.IndexOf("level") + 1;
				this.Level = Int32.Parse(key[index].ToString());
			}
			if (key.Contains("property"))
			{
				int index = key.IndexOf("property") + 1;
				this.Property = key[index].ToString();
			}

			//print out the array list of data 
			foreach (var item3 in key)
			{
				splitUrl = splitUrl + " " + item3;
			}
			urlString = splitUrl;
		}

		
		

		public String ReplaceCurly(String urlString)
		{
			urlString = urlString.Replace("{", string.Empty);
			urlString = urlString.Replace("}", string.Empty);
			return urlString;
		}

		public ArrayList Split(string urlString)
		{
			ArrayList key = new ArrayList();
			foreach (string item in SplitString(urlString))
			{

				foreach (string item2 in SplitString2(item))
				{

					String noQuotes = item2.Replace("\"", string.Empty);
					key.Add(noQuotes);
				}
			}
			return key;
		}

		public Array SplitString(string urlString)
		{
			return urlString.Split(','); 

		}
		public Array SplitString2(string item)
		{
			return item.Split(':');
		}


	
	} 
}