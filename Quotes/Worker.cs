using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Quotes
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private DataBase _db;

        public Worker(ILogger<Worker> logger, DataBase db)
        {
            _logger = logger;
            _db = db;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);

                DeleteExpiredQuotes();

            }
        }

        private void DeleteExpiredQuotes()
        {
            var quotes = _db;

            quotes.RemoveAll(x => (DateTime.Now - x.CreatedDate).Hours > 24);

            _db = quotes;
        }
    }
}
