using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo05.ViewComponents
{
    // Important note: I borrowed this example code from http://www.strathweb.com/2015/07/viewcomponents-asp-net-5-asp-net-mvc-6/
    // because it's really good, and represents everything pretty well, but I modified
    // it to show the option of passing arguments to the view components

    public class Product
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }

    public interface IProductService
    {
        Task<Product[]> GetPromotedProducts(decimal maxPrice);
    }

    public class ProductService : IProductService
    {
        public Task<Product[]> GetPromotedProducts(decimal maxPrice)
        {
            //for simplicity data is in memory
            var data = new[]
            {
            new Product
            {
                Name = "Etape: 20 Great Stages from the Modern Tour de France",
                Price = 9.90m
            },
            new Product
            {
                Name = "Anarchy Evolution: Faith, Science and Bad Religion in a World Without God",
                Price = 8.90m
            },
            new Product
            {
                Name = "The Bright Continent: Breaking Rules and Making Changes in Modern Africa",
                Price = 12.50m
            }
        };
            return Task.FromResult(data.Where(x => x.Price <= maxPrice).ToArray());
        }
    }
}