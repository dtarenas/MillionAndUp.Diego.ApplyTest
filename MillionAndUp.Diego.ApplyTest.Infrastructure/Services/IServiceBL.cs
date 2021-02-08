namespace MillionAndUp.Diego.ApplyTest.Infrastructure.Services
{
    using MillionAndUp.Diego.ApplyTest.Domain.ViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Service Bussines Logic Facade
    /// </summary>
    public interface IServiceBL
    {
        /// <summary>
        /// Gets the author listing.
        /// </summary>
        /// <returns>Author View Model</returns>
        Task<List<AuthorViewModel>> GetAuthorListing();

        /// <summary>
        /// Gets the editorial listing.
        /// </summary>
        /// <returns>Editorial View Model</returns>
        Task<List<EditorialViewModel>> GetEditorialListing();

        /// <summary>
        /// Gets the book listing.
        /// </summary>
        /// <returns>Book View model</returns>
        Task<List<BookViewModel>> GetBookListing();
    }
}