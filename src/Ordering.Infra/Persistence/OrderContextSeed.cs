using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;

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
                new Order() {UserName = "swn", FirstName = "Mehmet", LastName = "Ozkaya", EmailAddress = "ezozkme@gmail.com", AddressLine = "Bahcelievler", Country = "Turkey", TotalPrice = 350 },
                new Order() {UserName = "john_doe", FirstName = "John", LastName = "Doe", EmailAddress = "john.doe@example.com", AddressLine = "123 Main St", Country = "USA", TotalPrice = 500 },
                new Order() {UserName = "maria_silva", FirstName = "Maria", LastName = "Silva", EmailAddress = "maria.silva@example.com", AddressLine = "Rua Principal, 456", Country = "Brazil", TotalPrice = 200 },
                new Order() {UserName = "ali_khan", FirstName = "Ali", LastName = "Khan", EmailAddress = "ali.khan@example.com", AddressLine = "123 Khan Road", Country = "Pakistan", TotalPrice = 275 },
            };
        }
    }
}