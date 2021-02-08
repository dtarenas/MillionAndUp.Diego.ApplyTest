namespace MillionAndUp.Diego.ApplyTest.Infrastructure.DAL.Repo
{
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Generic repository facade
    /// </summary>
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// The get entity.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable" />.
        /// </returns>
        IQueryable<TEntity> Get();

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// TEntity Task
        /// </returns>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// Updates the specified author.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>TEntity</returns>
        public TEntity Update(TEntity entity);

        /// <summary>
        /// Removes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task</returns>
        Task RemoveAsync(int id);

        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        public Task SaveChangesAsync();

        /// <summary>
        /// Saves the changes.
        /// </summary>
        public void SaveChanges();
    }
}
