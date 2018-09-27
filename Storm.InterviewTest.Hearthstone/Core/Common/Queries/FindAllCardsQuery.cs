using System.Collections.Generic;
using System.Linq;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries.Base;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Common.Queries
{
	public class FindAllCardsQuery : CardListLinqQueryObject<ICard>
	{
		protected override IEnumerable<ICard> ExecuteLinq(IQueryable<ICard> queryOver)
		{
            return queryOver;
		}
	}
}