using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DbConnection;

namespace QuotingDojo.Controllers
{
    public class QuoteController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [Route("/quotes")]
        public IActionResult NewQuote(string name, string quote)
        {
            DbConnector.Execute($"INSERT INTO quotes (text, poster, created_at, updated_at) VALUES ('{quote}', '{name}', NOW(), NOW());");
            return RedirectToAction("ShowQuotes");
        }

        [HttpGet]
        [Route("/quotes")]
        public IActionResult ShowQuotes()
        {
            ViewBag.quoteList = DbConnector.Query("SELECT * FROM quotes ORDER BY updated_at DESC");
            return View("Show");
        }
    }
}