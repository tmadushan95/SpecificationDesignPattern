using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SpecificationDesignPattern.Domain;
using SpecificationDesignPattern.Repository;
using SpecificationDesignPattern.Repository.Interface;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        // Regiter DbContext
        services.AddDbContext<SpecificationDesignPatternDbContext>(options =>
        {
            options.UseSqlServer("Your_Connection_String_Here");
        });

        services.AddScoped<IOrderRepository, OrderRepository>();
    })
    .Build();

using var scope = host.Services.CreateScope();
var app = scope.ServiceProvider.GetRequiredService<IOrderRepository>();

await app.GetOrderByIdWithCustomerAsync(1);
