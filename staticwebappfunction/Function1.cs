using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace staticwebappfunction
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
            HttpRequest req,
            ILogger log)
        {
            var products = new List<Product>
            {
                new Product
                {
                    Name = "Phone",
                    Price = 999.90m,
                    Description = "This is the description of the phone"
                },
                new Product
                {
                    Name = "Book",
                    Price = 99.90m,
                    Description = "The best book you will ever read"
                },
                new Product
                {
                    Name = "TV",
                    Price = 15.49m,
                    Description = "Here you can see an awesome TV"
                }
            };

            return new OkObjectResult(JsonConvert.SerializeObject(products));
        }
    }
}