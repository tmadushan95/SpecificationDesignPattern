using Microsoft.EntityFrameworkCore;

namespace SpecificationDesignPattern.Domain
{
    /// <summary>
    /// Represents the Entity Framework Core database context for the Specification Design Pattern sample application.
    /// </summary>
    /// <remarks>This context provides access to the application's Users and Orders entities through DbSet
    /// properties. It should be registered and managed using dependency injection in ASP.NET Core applications. The
    /// context is intended for use with Entity Framework Core and supports standard EF Core features such as change
    /// tracking and LINQ queries.</remarks>
    /// <param name="options">The options to be used by the database context, including configuration such as the database provider and
    /// connection string.</param>
    public class SpecificationDesignPatternDbContext(DbContextOptions<SpecificationDesignPatternDbContext> options) 
        : DbContext(options)
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
    }
}
