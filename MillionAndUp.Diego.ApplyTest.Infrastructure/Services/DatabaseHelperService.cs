namespace MillionAndUp.Diego.ApplyTest.Infrastructure.Services
{
    using Microsoft.EntityFrameworkCore;
    using MillionAndUp.Diego.ApplyTest.Infrastructure.DAL.DbContexts;
    using System.Threading.Tasks;

    /// <summary>
    /// Database Helper Service
    /// </summary>
    public class DatabaseHelperService
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly BookshopDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseHelperService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public DatabaseHelperService(BookshopDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Applies the migrations asycn.
        /// </summary>
        public async Task ApplyMigrationsAsync()
        {
            await this._context.Database.MigrateAsync();
        }
    }
}
