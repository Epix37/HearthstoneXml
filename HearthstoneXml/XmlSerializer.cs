using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HearthstoneXml
{
	public class XmlSerializer<T>
	{
		public static T Load(string path)
		{
			T instance;
			using (TextReader reader = new StreamReader(path))
			{
				var xml = new XmlSerializer(typeof(T));
				instance = (T)xml.Deserialize(reader);
			}
			return instance;
		}

		public static T LoadFromString(string xmlString)
		{
			T instance;
			using (TextReader reader = new StringReader(xmlString))
			{
				var xml = new XmlSerializer(typeof(T));
				instance = (T)xml.Deserialize(reader);
			}
			return instance;
		}

		public static void Save(string path, object obj)
		{
			using (TextWriter writer = new StreamWriter(path))
			{
				var xml = new XmlSerializer(typeof(T));
				xml.Serialize(writer, obj);
			}
		}
	}
}
