using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Tests.Base;
using Storm.InterviewTest.Hearthstone.Tests.Specification;

namespace Storm.InterviewTest.Hearthstone.Tests.Queries
{
	[Category("Cache")]
	public class WhenSearchingHearthstoneCardsWithNameContainingSpecificQueryTerm : HearthstoneCardCacheContext
	{
		protected IEnumerable<ICard> _result;
        protected IEnumerable<ICard> _result2;
		protected string query;
        protected string query2;
        protected string query3;

        protected override IEnumerable<ICard> Cards()
		{
			return new List<ICard>(base.Cards())
			{
				CreateRandomMinionCardWithId("99", minion =>
				{
					minion.Name = "my special card";
					minion.Faction = FactionTypeOptions.Alliance;
					minion.Rarity = RarityTypeOptions.Legendary;
                    minion.PlayerClass = "Minion";
				})
			};
		}

		protected override void Context()
		{
			query = "special";
            query2 = "minion";
        }

		protected override void Because()
		{
			_result = _hearthstoneCardCache.Query(new SearchCardsQuery(query));
            _result2 = _hearthstoneCardCache.Query(new SearchCardsQuery(query2));
        }

		[Test]
		public void ShouldReturnExpectedSearchResults()
		{
			_result.Count().ShouldEqual(1);
			_result.First().Name.ShouldEqual("my special card");

            _result2.Count().ShouldEqual(3);
            _result2.First().Type.ToString().ShouldEqual("Minion");
        }
		

	}
}


