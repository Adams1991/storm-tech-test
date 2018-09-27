using System;
using System.Collections.Generic;
using System.Linq;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries.Base;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Common.Queries
{
	public class SearchCardsQuery : CardListLinqQueryObject<ICard>
	{
		private readonly string _q;

		public SearchCardsQuery(string q)
		{
			_q = q ?? string.Empty;
		}

		protected override IEnumerable<ICard> ExecuteLinq(IQueryable<ICard> queryOver)
            // changes Type part of conditional so comparing lower case regardless of user input
		{
            
            return queryOver.Where(x => (x.Name.Contains(_q) || x.Type.ToString().ToLower() == _q.ToLower() || 
            (x.PlayerClass != null && x.PlayerClass.ToLower() == _q.ToLower())) && !x.Id.StartsWith("HERO"));
            
		}
	}
}