using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes
{
    public class DataBase : List<QuoteModel>
    {
        
        public DataBase()
        {
            new List<QuoteModel>();

            Add(new QuoteModel()
            {
                Id = 1,
                Category = 1,
                Quote = "Everyone thinks of changing the world, but no one thinks of changing himself.",
                Author = "Leo Tolstoy",
            });

            Add(new QuoteModel()
            {
                Id = 2,
                Category = 1,
                Quote = "The way to make people trust-worthy is to trust them.",
                Author = "Ernest Hemingway",
            });

            Add(new QuoteModel()
            {
                Id = 3,
                Category = 2,
                Quote = "If you gaze long enough into an abyss, the abyss will gaze back into you.",
                Author = "Friedrich Nietzsche",
            });            
            
            Add(new QuoteModel()
            {
                Id = 4,
                Category = 2,
                Quote = "We are not rich by what we possess but by what we can do without.",
                Author = "Immanuel Kant",
            });

            Add(new QuoteModel()
            {
                Id = 5,
                Category = 3,
                Quote = "Politics is war without bloodshed while war is politics with bloodshed.",
                Author = "Mao Zedong",
            });
        }
    }
}
