using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Quotes
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private List<QuoteModel> _quotes;
        private List<SubscribeModel> _subscribes;
        public DateTime SendTime { get; set; }

        public Worker(ILogger<Worker> logger, DataBase db)
        {
            _logger = logger;
            _quotes = db.Quotes;
            _subscribes = db.Subscribes;
            SendTime = DateTime.Now;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
                DeleteExpiredQuotes();

                if (SendTime.Day == DateTime.Now.Day)
                {
                    SendDailyQuotes();
                }

            }
        }

        private void DeleteExpiredQuotes()
        {
            var quotes = _quotes;

            quotes.RemoveAll(x => (DateTime.Now - x.CreatedDate).Hours > 24);

            _quotes = quotes;
        }

        private void SendDailyQuotes()
        {
            foreach (var quote in _quotes)
            {
                foreach (var subscribe in _subscribes)
                {
                    if (!String.IsNullOrEmpty(subscribe.Phone))
                    {
                        SendSMS();
                    }

                    if (!String.IsNullOrEmpty(subscribe.Email))
                    {
                        SendEmail();
                    }
                }
            }

            SendTime.AddDays(1);
        }

        private void SendSMS()
        {

        }

        private void SendEmail()
        {

        }

    }
}
