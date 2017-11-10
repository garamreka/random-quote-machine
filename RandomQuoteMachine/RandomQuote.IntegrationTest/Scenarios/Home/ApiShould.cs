using Microsoft.EntityFrameworkCore;
using RandomQuote.IntegrationTest.TestFixtures;
using RandomQuoteMachine.Entities;
using RandomQuoteMachine.Models;
using RandomQuoteMachine.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RandomQuote.IntegrationTest.Scenarios.Home
{
    [Collection("BaseCollection")]
    public class ApiShould
    {
        private TestContext Context;

        public ApiShould(TestContext context)
        {
            //arrange
            Context = context;
        }

        [Fact]
        public async Task AddNewQuote()
        {
            //arrange
            var options = new DbContextOptionsBuilder<QuoteContext>().UseInMemoryDatabase(databaseName: "QuoteTestDb").Options;

            using (var dbContext = new QuoteContext(options))
            {
                var quoteRepository = new QuoteRepository(dbContext);

                //act
                dbContext.Quotes.Add(new Quote()
                {
                    Content = "It’s a dangerous business, Frodo, going out your door. You step onto the road, and if you don’t keep your feet, there’s no knowing where you might be swept off to.",
                    Author = "Bilbo"
                });
                dbContext.SaveChanges();

                //assert
                string expected = "Bilbo";
                var quote = await dbContext.Quotes.FirstOrDefaultAsync(q => q.Author.Equals("Bilbo"));
                Assert.Equal(expected, quote.Author);

            }
        }

        [Fact]
        public async Task ReturnOkStatus()
        {
            //act
            var response = await Context.Client.GetAsync("/api");
            string responseJson = await response.Content.ReadAsStringAsync();

            //assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ReturnContent()
        {
            //act
            var response = await Context.Client.GetAsync("/api");
            string responseJson = await response.Content.ReadAsStringAsync();

            //assert
            Assert.NotNull(responseJson);
        }
    }
}
