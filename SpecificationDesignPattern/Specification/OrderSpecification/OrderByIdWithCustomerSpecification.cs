using SpecificationDesignPattern.Domain;

namespace SpecificationDesignPattern.Specification
{
    internal class OrderByIdWithCustomerSpecification : Specification<Order>
    {
        /// <summary>
        /// Initializes a new instance of the OrderByIdWithCustomerSpecification class to filter orders by the specified
        /// order ID and include the associated customer information.
        /// </summary>
        /// <remarks>This specification can be used to retrieve an order along with its related customer
        /// entity in a single query. Useful when customer details are required together with the order.</remarks>
        /// <param name="orderId">The unique identifier of the order to filter. Must be a valid order ID.</param>
        public OrderByIdWithCustomerSpecification(int orderId)
            : base(o => o.Id == orderId)
        {
            AddInclude(order => order.Customer);
        }
    }
}
