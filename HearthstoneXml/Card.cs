namespace HearthstoneXml
{
	public class Card
	{
		public string CardId { get; set; }
		public string Name { get; set; }
		public string CardSet { get; set; }
		public string Rarity { get; set; }
		public string Type { get; set; }
		public int Attack { get; set; }
		public int Health { get; set; }
		public int Cost { get; set; }
		public int Durability { get; set; }
		public string Class { get; set; }
		public string Faction { get; set; }
		public string Race { get; set; }
		public string Text { get; set; }
		public string[] Mechanics { get; set; }
		public string Artist { get; set; }
	}
}