using System.Collections.Generic;
using System.Xml.Serialization;

namespace HearthstoneXml
{
	[XmlRoot(ElementName = "CardDb")]
	public class CardDb
	{
		[XmlElement(ElementName = "Card")]
		public List<Card> Cards { get; set; }
	}
}