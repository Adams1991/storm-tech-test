using System;
using System.Collections.Generic;
using System.Linq;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries.Base;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Common.Queries
{
    public class FilterCardsQuery : CardListLinqQueryObject<ICard>
    {
        private readonly string _q;

        public FilterCardsQuery(string q)
        {
            _q = q ?? string.Empty;
        }

        protected override IEnumerable<ICard> ExecuteLinq(IQueryable<ICard> queryOver)
        // changes Type part of conditional so comparing lower case regardless of user input
        {

            return queryOver.Where(x => _q == "all classes" || (x.PlayerClass != null && x.PlayerClass.ToLower() == _q.ToLower()));

        }
    }
}