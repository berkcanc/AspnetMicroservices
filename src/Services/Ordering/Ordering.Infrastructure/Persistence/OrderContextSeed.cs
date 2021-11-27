using Microsoft.Extensions.Logging;
using Ordering.Domain.Enitites;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order() {UserName = "swn",
                            FirstName = "Berkcan",
                            LastName = "Ciftci",
                            EmailAddress = "berkcanciftci35@gmail.com",
                            AddressLine = "Izmir",
                            Country = "Turkey",
                            TotalPrice = 350 }
            };
        }
    }
}
