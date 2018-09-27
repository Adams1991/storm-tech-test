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
        protected IEnumerable<ICard> _result3;
        protected IEnumerable<ICard> _result4;
        protected IEnumerable<ICard> _result5;
        protected string nameQuery;
        protected string lowerCaseTypeQuery;
        protected string upperCaseTypeQuery;
        protected string lowerCasePlayerClassQuery;
        protected string upperCasePlayerClassQuery;

        protected override IEnumerable<ICard> Cards()
		{
			return new List<ICard>(base.Cards())
			{
				CreateRandomMinionCardWithId("99", minion =>
				{
					minion.Name = "my special card";
					minion.Faction = FactionTypeOptions.Alliance;
					minion.Rarity = RarityTypeOptions.Legendary;
                    minion.PlayerClass = "Neutral";
				}),


                  CreateRandomMinionCardWithId("HERO", minion =>
                {
                    minion.Name = "A MINION HERO?";
                    minion.Faction = FactionTypeOptions.Alliance;
                    minion.Rarity = RarityTypeOptions.Legendary;
                    minion.PlayerClass = "Neutral";
                })
            };
		}

		protected override void Context()
		{
			nameQuery = "special";

            lowerCaseTypeQuery = "minion";

            upperCaseTypeQuery = "Minion";

            lowerCasePlayerClassQuery = "neutral";

            upperCasePlayerClassQuery = "Neutral";
        }

		protected override void Because()
		{
			_result = _hearthstoneCardCache.Query(new SearchCardsQuery(nameQuery));

            _result2 = _hearthstoneCardCache.Query(new SearchCardsQuery(lowerCaseTypeQuery));

            _result3 = _hearthstoneCardCache.Query(new SearchCardsQuery(upperCaseTypeQuery));

            _result4 = _hearthstoneCardCache.Query(new SearchCardsQuery(lowerCasePlayerClassQuery));

            _result5 = _hearthstoneCardCache.Query(new SearchCardsQuery(upperCasePlayerClassQuery));
        }

		[Test]
		public void ShouldReturnExpectedSearchResults()
		{
            // leaving initial test for names containing
			_result.Count().ShouldEqual(1);
			_result.First().Name.ShouldEqual("my special card");

            // below results tests input of both lower and uppercase pertaining to Type 
            _result2.Count().ShouldEqual(3);
            _result2.First().Type.ToString().ShouldEqual("Minion");

            _result3.Count().ShouldEqual(3);
            _result3.First().Type.ToString().ShouldEqual("Minion");

            // below results tests input of both lower and uppercase pertaining to Type 
            _result4.Count().ShouldEqual(1);
            _result4.First().PlayerClass.ShouldEqual("Neutral");

            _result5.Count().ShouldEqual(1);
            _result5.First().PlayerClass.ShouldEqual("Neutral");
        }
		

	}
}


