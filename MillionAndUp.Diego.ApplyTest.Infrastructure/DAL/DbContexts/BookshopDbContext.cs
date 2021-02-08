namespace MillionAndUp.Diego.ApplyTest.Infrastructure.DAL.DbContexts
{
    using Microsoft.EntityFrameworkCore;
    using MillionAndUp.Diego.ApplyTest.Domain.Entities;

    /// <summary>
    /// Bookshop Database Context
    /// </summary>
    public class BookshopDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookshopDbContext"/> class.
        /// </summary>
        /// <param name="opts">The opts.</param>
        public BookshopDbContext(DbContextOptions<BookshopDbContext> opts) : base(opts)
        {
        }

        /// <summary>
        /// Gets or sets the authors.
        /// </summary>
        /// <value>
        /// The authors.
        /// </value>
        public virtual DbSet<AuthorEntity> Authors{ get; set; }

        /// <summary>
        /// Gets or sets the books.
        /// </summary>
        /// <value>
        /// The books.
        /// </value>
        public virtual DbSet<BookEntity> Books { get; set; }

        /// <summary>
        /// Gets or sets the editorials.
        /// </summary>
        /// <value>
        /// The editorials.
        /// </value>
        public virtual DbSet<EditorialEntity> Editorials { get; set; }
    }
}
