using Microsoft.EntityFrameworkCore;
using SpecificationDesignPattern.Domain;
using SpecificationDesignPattern.Repository.Interface;
using SpecificationDesignPattern.Specification;
using SpecificationDesignPattern.Specification.OrderSpecification;

namespace SpecificationDesignPattern.Repository
{
    public class OrderRepository(SpecificationDesignPatternDbContext db) : IOrderRepository
    {
        // Injecting DbContext 
        private readonly SpecificationDesignPatternDbContext _db = db;

        /// <summary>
        /// Asynchronously retrieves an order by its unique identifier, including the associated customer information.
        /// </summary>
        /// <param name="orderId">The unique identifier of the order to retrieve. Must be a positive integer.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the matching <see cref="Order"/>
        /// with customer details if found; otherwise, <see langword="null"/>.</returns>
        public async Task<Order?> GetOrderByIdWithCustomerAsync(
            int orderId) =>
            await ApplySpecification(new OrderByIdWithCustomerSpecification(orderId))
                .FirstOrDefaultAsync();

        /// <summary>
        /// Asynchronously retrieves a list of orders associated with the specified customer name.
        /// </summary>
        /// <param name="customerName">The name of the customer whose orders are to be retrieved. Cannot be null or empty.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of orders for the
        /// specified customer. If no orders are found, the list will be empty.</returns>
        public async Task<List<Order>> GetOrderByCustomerAsync(
            string customerName) =>
            await ApplySpecification(new OrderByCustomerNameSpecification(customerName))
                .ToListAsync();

        #region Private Helper Methods
        /// <summary>
        /// Applies the specified criteria to the set of orders and returns a queryable collection that matches the
        /// specification.
        /// </summary>
        /// <param name="specification">The specification that defines the filtering, sorting, or projection rules to apply to the orders. Cannot be
        /// null.</param>
        /// <returns>An <see cref="IQueryable{Order}"/> representing the orders that satisfy the given specification.</returns>
        private IQueryable<Order> ApplySpecification(
            Specification<Order> specification)
        {
            return SpecificationEvaluator.GetQuery<Order>(
                _db.Set<Order>(),
                specification);
        }

        #endregion

    }
}
