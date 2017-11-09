using RandomQuoteMachine.Entities;
using RandomQuoteMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomQuoteMachine.Repositories
{
    public class QuoteRepository
    {
        QuoteContext QuoteContext;

        public QuoteRepository(QuoteContext quoteContext)
        {
            QuoteContext = quoteContext;
        }

        public List<Quote> GetAllQuote()
        {
            return QuoteContext.Quotes.ToList();
        }

        public Quote GetQuote()
        {
            return QuoteContext.Quotes.FirstOrDefault();
        }

        public Quote GetRandomQuote()
        {
            var quoteList = GetAllQuote();
            var random = new Random();
            var randomIndex = random.Next(quoteList.Count);

            return quoteList[randomIndex];
        }
    }
}
