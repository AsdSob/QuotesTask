using System;
using System.Collections.Generic;

namespace Quotes
{
    public class DataBase
    {
        public List<QuoteModel> Quotes { get; set; }
        public List<SubscribeModel> Subscribes { get; set; }

        public DataBase()
        {
            Quotes = new List<QuoteModel>();
            Subscribes = new List<SubscribeModel>();

            Subscribes.Add(new SubscribeModel()
            {
                Email = "Sam@gmail.com",
                UserName = "Sam",
            });

            Subscribes.Add(new SubscribeModel()
            {
                Phone = "+998998887766",
                UserName = "Tolstoy",
            });            Subscribes.Add(new SubscribeModel()
            {
                Email = "Hemingway@gmail.com",
                Phone = "+9981763652",
                UserName = "Hemingway",
            });

            Quotes.Add(new QuoteModel()
            {
                Id = 1,
                Category = 1,
                Quote = "Everyone thinks of changing the world, but no one thinks of changing himself.",
                Author = "Leo Tolstoy",
                CreatedDate = DateTime.Now,
            });

            Quotes.Add(new QuoteModel()
            {
                Id = 2,
                Category = 1,
                Quote = "The way to make people trust-worthy is to trust them.",
                Author = "Ernest Hemingway",
                CreatedDate = DateTime.Now,
            });

            Quotes.Add(new QuoteModel()
            {
                Id = 3,
                Category = 2,
                Quote = "If you gaze long enough into an abyss, the abyss will gaze back into you.",
                Author = "Friedrich Nietzsche",
                CreatedDate = DateTime.Now,
            });

            Quotes.Add(new QuoteModel()
            {
                Id = 4,
                Category = 2,
                Quote = "We are not rich by what we possess but by what we can do without.",
                Author = "Immanuel Kant",
                CreatedDate = DateTime.Now,
            });

            Quotes.Add(new QuoteModel()
            {
                Id = 5,
                Category = 3,
                Quote = "Politics is war without bloodshed while war is politics with bloodshed.",
                Author = "Mao Zedong",
                CreatedDate = DateTime.Now,
            });
        }
    }
}
