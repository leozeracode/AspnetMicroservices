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

        public static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
        {
            new Order
            {
                UserName = "alice_smith",
                TotalPrice = 30.25m,
                FirstName = "Alice",
                LastName = "Smith",
                EmailAddress = "alice.smith@example.com",
                AddressLine = "789 Elm St",
                Country = "USA",
                State = "TX",
                ZipCode = "56789",
                CardName = "Alice Smith",
                CardNumber = "5678-1234-9012-3456",
                Expiration = "10/24",
                CVV = "789",
                PaymentMethod = 1
            },
            new Order
            {
                UserName = "bob_jones",
                TotalPrice = 42.75m,
                FirstName = "Bob",
                LastName = "Jones",
                EmailAddress = "bob.jones@example.com",
                AddressLine = "101 Pine St",
                Country = "USA",
                State = "FL",
                ZipCode = "34567",
                CardName = "Bob Jones",
                CardNumber = "8765-4321-0987-6543",
                Expiration = "09/23",
                CVV = "012",
                PaymentMethod = 2
            },
            new Order
            {
                UserName = "emma_davis",
                TotalPrice = 65.50m,
                FirstName = "Emma",
                LastName = "Davis",
                EmailAddress = "emma.davis@example.com",
                AddressLine = "202 Maple St",
                Country = "USA",
                State = "IL",
                ZipCode = "45678",
                CardName = "Emma Davis",
                CardNumber = "4321-8765-2109-8765",
                Expiration = "08/22",
                CVV = "345",
                PaymentMethod = 1
            },
            new Order
            {
                UserName = "charlie_wilson",
                TotalPrice = 20.00m,
                FirstName = "Charlie",
                LastName = "Wilson",
                EmailAddress = "charlie.wilson@example.com",
                AddressLine = "303 Birch St",
                Country = "USA",
                State = "CA",
                ZipCode = "23456",
                CardName = "Charlie Wilson",
                CardNumber = "9876-5432-1098-7654",
                Expiration = "07/21",
                CVV = "678",
                PaymentMethod = 2
            }
        };
        }
    }
}