namespace SpecificationDesignPattern.Domain
{
    public class Order
    {
        /// <summary>
        /// Gets or sets the unique identifier for the entity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the order was placed.
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets the total monetary amount for the transaction.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the user associated with the customer account.
        /// </summary>
        public User Customer { get; set; } = new();
    }
}
