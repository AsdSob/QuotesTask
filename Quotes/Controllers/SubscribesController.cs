using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Quotes.Controllers
{
    [ApiController]
    [Route("subscribe")]
    public class SubscribesController : ControllerBase
    {

        private readonly ILogger<SubscribesController> _logger;
        private List<SubscribeModel> _db;

        public SubscribesController(ILogger<SubscribesController> logger, DataBase db)
        {
            this._db = db.Subscribes;
            _logger = logger;
        }

        /// <summary>
        /// Get all subscribes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<SubscribeModel> Get()
        {
            return _db.ToArray();
        }
        
        /// <summary>
        /// Create new subscribe
        /// </summary>
        /// <param name="subscribe"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<IActionResult> Create([FromBody] SubscribeModel subscribe)
        {
            _db.Add(subscribe);
            return Ok();
        }

    }
}
