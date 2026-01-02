using SpecificationDesignPattern.Domain;

namespace SpecificationDesignPattern.Specification.OrderSpecification
{
    internal class OrderByCustomerNameSpecification : Specification<Order>
    {
        /// <summary>
        /// Initializes a new instance of the OrderByCustomerNameSpecification class to filter orders by the specified
        /// customer name and sort them by order date.
        /// </summary>
        /// <remarks>This specification includes the related Customer entity in the query results and
        /// orders the returned orders by their order date in ascending order.</remarks>
        /// <param name="customerName">The name of the customer to filter orders by. Cannot be null.</param>
        public OrderByCustomerNameSpecification(string customerName)
            : base(o => o.Customer.Name == customerName)
        {

            AddInclude(o => o.Customer);

            AddOrderBy(o => o.OrderDate);
        }
    }
}
