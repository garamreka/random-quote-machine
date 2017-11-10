using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RandomQuoteMachine.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RandomQuoteMachine.Controllers
{
    public class HomeController : Controller
    {
        QuoteRepository QuoteRepository;

        public HomeController(QuoteRepository quoteRepository)
        {
            QuoteRepository = quoteRepository;
        }

        public HomeController()
        {
        }

        [HttpGet]
        [Route ("")]
        public IActionResult Index()
        {
            return File("index.html", "text/html");
        }

        [HttpGet]
        [Route("/api")]
        public IActionResult JsonResult()
        {
            return Json(new { content = QuoteRepository.GetRandomQuote().Content.ToString(), author = QuoteRepository.GetRandomQuote().Author.ToString() });
        }
    }
}
