using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneXml
{
	public class Dictionaries
	{
		public static readonly Dictionary<int, string> SetDict = new Dictionary<int, string>()
		{
			{0, null},
			{2, "Basic"},
			{3, "Classic"},
			{4, "Reward"},
			{5, "Missions"},
			{7, "System"},
			{8, "Debug"},
			{11, "Promotion"},
			{12, "Curse of Naxxramas"},
			{13, "Goblins vs Gnomes"},
			{14, "Blackrock Mountain"},
			{15, "The Grand Tournament"},
			{16, "Credits"},
			{17, "Hero Skins"},
			{18, "Tavern Brawl"}
		};

		public static readonly Dictionary<int, string> TypeDict = new Dictionary<int, string>()
		{
			{0, null},
			{3, "Hero"},
			{4, "Minion"},
			{5, "Spell"},
			{6, "Enchantment"},
			{7, "Weapon"},
			{10, "Hero Power"}
		};

		public static readonly Dictionary<int, string> FactionDict = new Dictionary<int, string>()
		{
			{0, null},
			{1, "Horde"},
			{2, "Alliance"},
			{3, "Neutral"}
		};

		public static readonly Dictionary<int, string> RarityDict = new Dictionary<int, string>()
		{
			{0, null},
			{1, "Common"},
			{2, "Free"},
			{3, "Rare"},
			{4, "Epic"},
			{5, "Legendary"}
		};

		public static readonly Dictionary<int, string> RaceDict = new Dictionary<int, string>()
		{
			{0, null},
			{14, "Murloc"},
			{15, "Demon"},
			{20, "Beast"},
			{21, "Totem"},
			{23, "Pirate"},
			{24, "Dragon"},
			{17, "Mech"}
		};

		public static readonly Dictionary<int, string> ClassDict = new Dictionary<int, string>()
		{
			{0, null},
			{2, "Druid"},
			{3, "Hunter"},
			{4, "Mage"},
			{5, "Paladin"},
			{6, "Priest"},
			{7, "Rogue"},
			{8, "Shaman"},
			{9, "Warlock"},
			{10, "Warrior"},
			{11, "Dream"}
		};

		public static readonly Dictionary<string, int> EnumDict = new Dictionary<string, int>()
		{
			{"CardName", 185},
			{"CardSet", 183},
			{"CardType", 202},
			{"Faction", 201},
			{"Class", 199},
			{"Rarity", 203},
			{"Cost", 48},
			{"AttackVisualType", 251},
			{"CardTextInHand", 184},
			{"Atk", 47},
			{"Health", 45},
			{"Collectible", 321},
			{"CardArtist", 342},
			{"FlavorText", 351},
			{"TriggerVisual", 32},
			{"EnchantmentBirthVisual", 330},
			{"EnchantmentIdleVisual", 331},
			{"DevState", 268},
			{"HowToGetThisGoldCard", 365},
			{"Taunt", 190},
			{"HowToGetThisCard", 364},
			{"OneTurnEffect", 338},
			{"Morph", 293},
			{"Freeze", 208},
			{"CardTextInPlay", 252},
			{"TargetingArrowText", 325},
			{"Windfury", 189},
			{"Battlecry", 218},
			{"Race", 200},
			{"Spellpower", 192},
			{"Durability", 187},
			{"Charge", 197},
			{"Aura", 362},
			{"HealTarget", 361},
			{"ImmuneToSpellpower", 349},
			{"Divine Shield", 194},
			{"AdjacentBuff", 350},
			{"Deathrattle", 217},
			{"Stealth", 191},
			{"Combo", 220},
			{"Silence", 339},
			{"Enrage", 212},
			{"AffectedBySpellPower", 370},
			{"Cant Be Damaged", 240},
			{"Elite", 114},
			{"Secret", 219},
			{"Poisonous", 363},
			{"Recall", 215},
			{"Counter", 340},
			{"Summoned", 205},
			{"AIMustPlay", 367},
			{"InvisibleDeathrattle", 335},
			{"UKNOWN_HasOnDrawEffect", 377},
			{"SparePart", 388},
			{"UNKNOWN_DuneMaulShaman", 389},
			{"UNKNOWN_Grand_Tournement_Fallen_Hero", 396},
			{"UNKNOWN_BroodAffliction", 401},
			{"Inspire", 403},
			{"UNKNOWN_Grand_Tournament_Arcane_Blast", 404}
		};
	}
}
