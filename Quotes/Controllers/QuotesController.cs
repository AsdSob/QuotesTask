using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.Controllers
{
    [ApiController]
    [Route("quotes")]
    public class QuotesController : ControllerBase
    {

        private readonly ILogger<QuotesController> _logger;
        private List<QuoteModel> _db;
        private Random _random;

        public QuotesController(ILogger<QuotesController> logger, DataBase db)
        {
            this._db = db.Quotes;
            _logger = logger;

            _random = new Random();
        }

        /// <summary>
        /// Get All quotes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<QuoteModel> Get()
        {
            return _db.ToArray();
        }

        /// <summary>
        /// Get random quote
        /// </summary>
        /// <returns></returns>
        [HttpGet("random")]
        public QuoteModel GetRandom()
        {
            int index = _random.Next(_db.Count);
            
            return _db[index];
        }

        /// <summary>
        /// Get quotes by category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpGet("category")]
        public IEnumerable<QuoteModel> Get(int category)
        {
            return _db.Where(x=> x.Category == category).ToArray();
        }
        
        /// <summary>
        /// Update quote
        /// </summary>
        /// <param name="quote"></param>
        /// <returns></returns>
        [HttpPut]
        public virtual async Task<IActionResult> Update([FromBody] QuoteModel quote)
        {
            _db[quote.Id-1] = quote;
           
            return Ok();
        }

        /// <summary>
        /// Create new quote
        /// </summary>
        /// <param name="quote"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<IActionResult> Create([FromBody] QuoteModel quote)
        {
            var newQuote = quote;
            newQuote.CreatedDate = DateTime.Now;
            
            _db.Add(newQuote);
            return Ok();
        }

        /// <summary>
        /// Delete quote by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("id")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            _db.Remove(_db[id-1]);
            return Ok();
        }
    }
}
