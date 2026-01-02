using System.Linq.Expressions;

namespace SpecificationDesignPattern.Specification
{
    public abstract class Specification<TEntity>(Expression<Func<TEntity, bool>>? criteria)
        where TEntity : class
    {
        /// <summary>
        /// Gets the predicate expression used to filter entities of type <typeparamref name="TEntity"/>.
        /// </summary>
        /// <remarks>The criteria expression defines the conditions that entities must satisfy to be
        /// included in query results. If <see langword="null"/>, no filtering is applied and all entities are
        /// included.</remarks>
        public Expression<Func<TEntity, bool>>? Criteria { get; } = criteria;

        /// <summary>
        /// Gets the collection of expressions that specify related entities to include when querying for <typeparamref
        /// name="TEntity"/> objects.
        /// </summary>
        /// <remarks>Use this property to define navigation properties that should be eagerly loaded as
        /// part of the query. Each expression in the collection represents a path to a related entity or property to
        /// include. This is commonly used in data access scenarios to optimize queries and reduce the number of
        /// database calls required to retrieve related data.</remarks>
        public List<Expression<Func<TEntity, object>>> IncludeExpression { get; } = [];

        /// <summary>
        /// Gets the expression used to specify the property or value by which entities are ordered in a query.
        /// </summary>
        /// <remarks>The expression defines the ordering criteria for query results. If <see
        /// langword="null"/>, no specific ordering is applied. This property is typically set when constructing queries
        /// that require ordered results.</remarks>
        public Expression<Func<TEntity, object>>? OrderByExpression { get; private set; }

        /// <summary>
        /// Gets the expression used to specify the property by which to order entities in descending order.
        /// </summary>
        /// <remarks>Use this property to define a descending sort order when querying entities of type
        /// <typeparamref name="TEntity"/>. If the value is <see langword="null"/>, no descending order will be
        /// applied.</remarks>
        public Expression<Func<TEntity, object>>? OrderByDescendingExpression { get; private set; }

        /// <summary>
        /// Adds an include expression to specify a related entity to be included in query results.
        /// </summary>
        /// <remarks>Use this method to enable eager loading of related entities when constructing
        /// queries. Multiple include expressions can be added to include multiple related entities.</remarks>
        /// <param name="includeExpression">An expression that identifies the related entity to include. Typically specifies a navigation property of
        /// <typeparamref name="TEntity"/>. Cannot be null.</param>
        protected void AddInclude(Expression<Func<TEntity, object>> includeExpression) =>
            IncludeExpression.Add(includeExpression);

        /// <summary>
        /// Specifies the expression used to order query results for the current entity type.
        /// </summary>
        /// <remarks>Calling this method replaces any previously set ordering expression for the entity.
        /// The specified expression is typically used in LINQ queries to determine the sort order of results.</remarks>
        /// <param name="orderByExpression">An expression that defines the property or value by which to order the results. Cannot be null.</param>
        protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression) =>
            OrderByExpression = orderByExpression;

        /// <summary>
        /// Specifies a descending order for query results based on the provided expression.
        /// </summary>
        /// <param name="orderByDescendingExpression">An expression that defines the property of <typeparamref name="TEntity"/> to order the results by in
        /// descending order. Cannot be null.</param>
        protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescendingExpression) =>
            OrderByDescendingExpression = orderByDescendingExpression;
    }
}
