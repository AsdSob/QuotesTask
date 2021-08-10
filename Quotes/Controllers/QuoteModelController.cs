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
    public class QuoteModelController : ControllerBase
    {

        private readonly ILogger<QuoteModelController> _logger;
        private DataBase _db;

        public QuoteModelController(ILogger<QuoteModelController> logger, DataBase db)
        {
            this._db = db;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<QuoteModel> Get()
        {
            return _db.ToArray();
        }

        [HttpGet("random")]
        public QuoteModel GetRandom()
        {
            var random = new Random();
            int index = random.Next(_db.Count);
            
            return _db[index];
        }

        [HttpGet("category")]
        public IEnumerable<QuoteModel> Get(int category)
        {
            return _db.Where(x=> x.Category == category).ToArray();
        }
        
        [HttpPut]
        public virtual async Task<IActionResult> Update([FromBody] QuoteModel quote)
        {
            _db[quote.Id-1] = quote;
           
            return Ok();
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create([FromBody] QuoteModel quote)
        {
            var newQuote = quote;
            newQuote.CreatedDate = DateTime.Now;
            
            _db.Add(newQuote);
            return Ok();
        }

        [HttpDelete("id")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            _db.Remove(_db[id-1]);
            return Ok();
        }
    }
}
