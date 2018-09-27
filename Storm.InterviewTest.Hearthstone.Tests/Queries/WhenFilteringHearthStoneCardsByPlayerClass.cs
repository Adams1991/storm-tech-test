using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Tests.Base;
using Storm.InterviewTest.Hearthstone.Tests.Specification;

namespace Storm.InterviewTest.Hearthstone.Tests.Queries
{
    class WhenFilteringHearthStoneCardsByPlayerClass : HearthstoneCardCacheContext
    {
        protected IEnumerable<ICard> _resultForNoFilter;
        protected IEnumerable<ICard> _resultForFilter;
        protected IEnumerable<ICard> _resultForFilterAndSearchTerm;
        protected string noFilter;
        protected string playerClassFilter;
        protected string searchTerm;


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

                  CreateRandomMinionCardWithId("10", minion =>
                {
                    minion.Name = "filter works";
                    minion.Faction = FactionTypeOptions.Alliance;
                    minion.Rarity = RarityTypeOptions.Legendary;
                    minion.PlayerClass = "Neutral";
                })
            };
        }



        protected override void Context()
        {
            noFilter = "all classes";
            playerClassFilter = "Neutral";
            searchTerm = "filter works with search term";
        }


        protected override void Because()
        {
            _resultForNoFilter = _hearthstoneCardCache.Query(new FilterCardsQuery(noFilter));
            _resultForFilter = _hearthstoneCardCache.Query(new FilterCardsQuery(playerClassFilter));
        }


        [Test]
        public void ShouldReturnExpectedSearchResults()
        {
            _resultForNoFilter.Count().ShouldEqual(6);

            _resultForFilter.Count().ShouldEqual(2);
        }
    }
}
