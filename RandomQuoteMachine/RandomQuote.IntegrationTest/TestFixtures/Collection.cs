using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RandomQuote.IntegrationTest.TestFixtures
{
    [CollectionDefinition("BaseCollection")]
    public class Collection : ICollectionFixture<TestContext>
    {
    }
}
