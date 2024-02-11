using MapsterSample;
using MapsterSample.Models;
using MapsterSample.Services;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        ServiceCollection services = new();

        services.AddScoped<ICustomerService, CustomerService>();

        var provider = services.BuildServiceProvider();

        MapsterConfiguration.ConfigureMapster();

        var customerService = provider.GetService<ICustomerService>();
        var customerDtos = customerService.GetCustomers();

        var customerDto = new CustomerDto()
        {
            Id = 3,
            //FirstName = "Arthur",
            //LastName = "Curry",
            Name = "Arthur Curry",
            City = "Atlantis",
            Order = new OrderDto() { Id = 4, ItemName = "Cape", ItemColor = Color.Green }
        };

        customerDtos = customerService.AddCustomer(customerDto);

        Console.Read();
    }
}