using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomQuoteMachine.Models
{
    public class Quote
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}
