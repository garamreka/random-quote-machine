using Microsoft.EntityFrameworkCore;
using RandomQuoteMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomQuoteMachine.Entities
{
    public class QuoteContext : DbContext
    {
        public QuoteContext(DbContextOptions<QuoteContext> options) : base(options)
        {

        }

        public DbSet<Quote> Quotes { get; set; }
    }
}
