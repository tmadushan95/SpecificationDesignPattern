using Microsoft.EntityFrameworkCore;

namespace SpecificationDesignPattern.Specification
{
    public static class SpecificationEvaluator
    {
        /// <summary>
        /// // Applies the given specification to the input queryable and returns the resulting queryable.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="inputQueryable"></param>
        /// <param name="specification"></param>
        /// <returns></returns>
        public static IQueryable<TEntity> GetQuery<TEntity>(
            IQueryable<TEntity> inputQueryable,
            Specification<TEntity> specification)
            where TEntity : class
        {
            // Start with the input queryable
            IQueryable<TEntity> queryable = inputQueryable;

            // Apply the criteria if it exists
            if (specification.Criteria is not null)
            {
                queryable = queryable.Where(specification.Criteria);
            }

            // Apply the include expressions
            queryable = specification.IncludeExpression.Aggregate(
                queryable,
                (current, includeExpression) => current.Include(includeExpression));

            // Apply ordering if specified
            if (specification.OrderByExpression is not null)
            {
                queryable = queryable.OrderBy(specification.OrderByExpression);
            }
            else if (specification.OrderByDescendingExpression is not null)
            {
                queryable = queryable.OrderByDescending(specification.OrderByDescendingExpression);
            }

            // Return the final queryable
            return queryable;
        }
    }
}
