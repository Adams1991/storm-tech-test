using System.Collections.Generic;
using System.IO;
using System.Web;
using Newtonsoft.Json.Linq;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services
{
	public class LocalJsonFeedHearthstoneCardCacheFactory : HearthstoneCardCacheFactory
	{
		public LocalJsonFeedHearthstoneCardCacheFactory(IHearthstoneCardParser parser) : base(parser)
		{
		}

		protected override IEnumerable<ICard> PopulateCards(IHearthstoneCardParser parser)
		{
			using (var reader = File.OpenText(HttpContext.Current.Server.MapPath("~/App_Data/cards.json")))
			{
				var cardSets = JObject.Parse(reader.ReadToEnd());
				JToken cards;
				if (cardSets.TryGetValue("Basic", out cards) && cards.Type == JTokenType.Array)
				{
					foreach (var card in cards)
					{
						var parsedCard = parser.Parse(card.ToString());
						if (parsedCard != null)
						{
							yield return parsedCard;
						}
					}
				}
				if (cardSets.TryGetValue("Classic", out cards) && cards.Type == JTokenType.Array)
				{
					foreach (var card in cards)
					{
						var parsedCard = parser.Parse(card.ToString());
						if (parsedCard != null)
						{
							yield return parsedCard;
						}
					}
				}
				if (cardSets.TryGetValue("Curse of Naxxramas", out cards) && cards.Type == JTokenType.Array)
				{
					foreach (var card in cards)
					{
						var parsedCard = parser.Parse(card.ToString());
						if (parsedCard != null)
						{
							yield return parsedCard;
						}
					}
				}
				if (cardSets.TryGetValue("Goblins vs Gnomes", out cards) && cards.Type == JTokenType.Array)
				{
					foreach (var card in cards)
					{
						var parsedCard = parser.Parse(card.ToString());
						if (parsedCard != null)
						{
							yield return parsedCard;
						}
					}
				}
			}
		}
	}
}