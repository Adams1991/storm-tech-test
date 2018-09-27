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
        protected IEnumerable<ICard> _result;
        protected string noFilter;


        protected override void Context()
        {
            noFilter = null;
        }


        protected override void Because()
        {
            _result = _hearthstoneCardCache.Query(new SearchCardsQuery(noFilter));
        }


        [Test]
        public void ShouldReturnExpectedSearchResults()
        {
            _result.Count().ShouldEqual(4);
        }
    }
}
