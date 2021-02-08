namespace MillionAndUp.Diego.ApplyTest.Infrastructure.DAL.Repo
{
    using Microsoft.EntityFrameworkCore;
    using MillionAndUp.Diego.ApplyTest.Infrastructure.DAL.DbContexts;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Generic Repository Implementation
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="MillionAndUp.Diego.ApplyTest.Infrastructure.DAL.Repo.IGenericRepository{TEntity}" />
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// The bookshop database context
        /// </summary>
        private readonly BookshopDbContext _bookshopDbContext;

        /// <summary>
        /// The database set
        /// </summary>
        public readonly DbSet<TEntity> DbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="bookshopDbContext">The bookshop database context.</param>
        public GenericRepository(BookshopDbContext bookshopDbContext)
        {
            this._bookshopDbContext = bookshopDbContext;
            this.DbSet = this._bookshopDbContext.Set<TEntity>();
        }

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// TEntity Task
        /// </returns>
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await this.DbSet.AddAsync(entity);
            return entity;
        }

        /// <summary>
        /// The get entity.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Linq.IQueryable" />.
        /// </returns>
        public IQueryable<TEntity> Get()
        {
            return this.DbSet.AsNoTracking().AsQueryable();
        }

        /// <summary>
        /// Removes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task RemoveAsync(int id)
        {
            var entity = await this.DbSet.FindAsync(id);
            this._bookshopDbContext.Remove(entity);
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        public void SaveChanges()
        {
            this._bookshopDbContext.SaveChanges();
        }

        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        public async Task SaveChangesAsync()
        {
            await this._bookshopDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Updates the specified author.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// TEntity
        /// </returns>
        public TEntity Update(TEntity entity)
        {
            this.DbSet.Attach(entity);
            this._bookshopDbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
