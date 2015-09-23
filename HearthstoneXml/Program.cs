#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using System.Xml.Serialization;

#endregion

namespace HearthstoneXml
{
	internal class Program
	{
		private const string DisunityVersion = "0.3.4";
		private const string DisunityDir = "disunity";
		private const string CardXml0 = "cardxml0.unity3d";

		public static readonly string[] Mechanics =
		{
			"Windfury",
			"Combo",
			"Secret",
			"Battlecry",
			"Deathrattle",
			"Taunt",
			"Stealth",
			"Spellpower",
			"Enrage",
			"Freeze",
			"Charge",
			"Overload",
			"Divine Shield",
			"Silence",
			"Morph",
			"OneTurnEffect",
			"Poisonous",
			"Aura",
			"AdjacentBuff",
			"HealTarget",
			"GrantCharge",
			"ImmuneToSpellpower",
			"AffectedBySpellPower",
			"Summoned",
			"Inspire"
		};

		private static string _cardXml0FilePath = @"C:\Program Files (x86)\Hearthstone\Data\Win\cardxml0.unity3d";
		public static List<XElement> Tags { get; set; }

		private static string DisunityBat
		{
			get { return Path.Combine(DisunityDir, "disunity.bat"); }
		}

		private static string DisunityUrl
		{
			get { return string.Format("https://github.com/ata4/disunity/releases/download/v{0}/disunity_v{0}.zip", DisunityVersion); }
		}

		private static string DisunityZipFile
		{
			get { return string.Format("disunity_v{0}.zip", DisunityVersion); }
		}

		private static void Main(string[] args)
		{
			if(args.Length > 0 && File.Exists(args[0]))
			{
				_cardXml0FilePath = args[0];
				Console.WriteLine("Set cardXml0 path to " + args[0]);
			}
			DownloadDisunity();
			Disunity();
			BuildXmlFiles();
			Console.WriteLine("Done.");
			Console.WriteLine("Saved files to \"{0}\"", Path.GetFullPath("Files"));
            Console.WriteLine("Press any key to continue.");
			Console.ReadKey();
		}

		private static void DownloadDisunity()
		{
			if(!File.Exists(DisunityBat))
			{
				Directory.CreateDirectory(DisunityDir);
				Console.WriteLine("Downloading Disunity...");
				using(var wc = new WebClient())
					wc.DownloadFile(DisunityUrl, DisunityZipFile);
				Console.WriteLine("Extracting Disunity...");
				ZipFile.ExtractToDirectory(DisunityZipFile, DisunityDir);
				File.Delete(DisunityZipFile);
			}
		}

		private static void Disunity()
		{
			while(!File.Exists(_cardXml0FilePath))
			{
				Console.WriteLine("Could not find \"{0}\". Please enter the correct path.", _cardXml0FilePath);
				_cardXml0FilePath = Console.ReadLine();
			}
			File.Copy(_cardXml0FilePath, CardXml0);
			Console.WriteLine("Running disunity...");
			var proc = new Process {StartInfo = new ProcessStartInfo {FileName = DisunityBat, Arguments = "extract cardxml0.unity3d"}};
			proc.Start();
			proc.WaitForExit();
			File.Delete(CardXml0);
		}

		private static void BuildXmlFiles()
		{
			Console.WriteLine("Deleting old files...");
			Directory.Delete("Files", true);
			Console.WriteLine("Building XML files...");
			const string dir = @"cardxml0\CAB-cardxml0\TextAsset";
			var dirInfo = new DirectoryInfo(dir);
			var cards = new List<Card>();
			foreach(var file in dirInfo.GetFiles())
			{
				Console.WriteLine("Processing {0}...", file.Name);
				cards.Clear();
				var doc = XDocument.Load(file.FullName);
				var entities = doc.Descendants("Entity");
				foreach(var entity in entities)
				{
					var cardId = entity.Attributes().FirstOrDefault(x => x.Name == "CardID").Value;

					Tags = entity.Descendants("Tag").ToList();
					var mechanics = Mechanics.Where(x => GetTagValue(x) != "0");

					cards.Add(new Card
					{
						Artist = GetTagValue("CardArtist", false),
						Attack = int.Parse(GetTagValue("Atk")),
						CardId = cardId,
						CardSet = Dictionaries.SetDict[int.Parse(GetTagValue("CardSet"))],
						Cost = int.Parse(GetTagValue("Cost")),
						Health = int.Parse(GetTagValue("Health")),
						Name = GetTagValue("CardName", false),
						Rarity = Dictionaries.RarityDict[int.Parse(GetTagValue("Rarity"))],
						Text = GetTagValue("CardTextInHand", false),
						Type = Dictionaries.TypeDict[int.Parse(GetTagValue("CardType"))],
						Class = Dictionaries.ClassDict[int.Parse(GetTagValue("Class"))],
						Faction = Dictionaries.FactionDict[int.Parse(GetTagValue("Faction"))],
						Race = Dictionaries.RaceDict[int.Parse(GetTagValue("Race"))],
						Durability = int.Parse(GetTagValue("Durability")),
						Mechanics = mechanics.ToArray()
					});
				}

				if(!Directory.Exists("Files"))
					Directory.CreateDirectory("Files");
				var xml = new XmlSerializer(typeof(CardDb));
				using(TextWriter tw = new StreamWriter("Files/cardDB." + file.Name.Replace(file.Extension, "") + ".xml"))
					xml.Serialize(tw, new CardDb {Cards = cards});
			}
			Directory.Delete("cardxml0", true);
		}

		private static string GetTagValue(string tagName, bool isInt = true)
		{
			if(!Dictionaries.EnumDict.ContainsKey(tagName))
				return (isInt ? "0" : null);
			var tag =
				Tags.FirstOrDefault(x => x.Attributes().Any(a => a.Name == "enumID" && a.Value == Dictionaries.EnumDict[tagName].ToString()));
			var valueTag = tag != null ? tag.Attributes().FirstOrDefault(a => a.Name == "value") : null;
			return valueTag != null ? valueTag.Value : (tag != null ? tag.Value : (isInt ? "0" : null));
		}
	}
}