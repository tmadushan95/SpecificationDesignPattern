namespace SpecificationDesignPattern.Domain
{
    public class User
    {
        /// <summary>
        /// Gets or sets the unique identifier for the entity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name associated with the object.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the username associated with the current user.
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email address associated with the user.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date and time when the object was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
