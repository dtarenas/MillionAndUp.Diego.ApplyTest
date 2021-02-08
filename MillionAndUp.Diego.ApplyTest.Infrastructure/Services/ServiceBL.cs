namespace MillionAndUp.Diego.ApplyTest.Infrastructure.Services
{
    using Microsoft.EntityFrameworkCore;
    using MillionAndUp.Diego.ApplyTest.Domain.Entities;
    using MillionAndUp.Diego.ApplyTest.Domain.ViewModels;
    using MillionAndUp.Diego.ApplyTest.Infrastructure.DAL.Repo;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Service Bussines logic implementation
    /// </summary>
    /// <seealso cref="MillionAndUp.Diego.ApplyTest.Infrastructure.Services.IServiceBL" />
    public class ServiceBL : IServiceBL
    {
        /// <summary>
        /// The authors repository
        /// </summary>
        private readonly IGenericRepository<AuthorEntity> _authorsRepository;

        /// <summary>
        /// The editorials repository
        /// </summary>
        private readonly IGenericRepository<EditorialEntity> _editorialsRepository;

        /// <summary>
        /// The books repository
        /// </summary>
        private readonly IGenericRepository<BookEntity> _booksRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBL"/> class.
        /// </summary>
        /// <param name="authorsRepository">The authors repository.</param>
        /// <param name="editorialsRepository">The editorials repository.</param>
        /// <param name="booksRepository">The books repository.</param>
        public ServiceBL(IGenericRepository<AuthorEntity> authorsRepository, IGenericRepository<EditorialEntity> editorialsRepository, IGenericRepository<BookEntity> booksRepository)
        {
            this._authorsRepository = authorsRepository;
            this._editorialsRepository = editorialsRepository;
            this._booksRepository = booksRepository;
        }

        /// <summary>
        /// Gets the author listing.
        /// </summary>
        /// <returns>
        /// Author View Model
        /// </returns>
        public async Task<List<AuthorViewModel>> GetAuthorListing()
        {
            try
            {
                return await this._authorsRepository.Get().Select(x => new AuthorViewModel(x)).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Gets the book listing.
        /// </summary>
        /// <returns>
        /// Book View model
        /// </returns>
        public async Task<List<BookViewModel>> GetBookListing()
        {
            try
            {
                return await this._booksRepository.Get().Include(x => x.FkAuthor).Include(x => x.FkEditorial).Select(x => new BookViewModel(x)).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Gets the editorial listing.
        /// </summary>
        /// <returns>
        /// Editorial View Model
        /// </returns>
        public async Task<List<EditorialViewModel>> GetEditorialListing()
        {
            try
            {
                return await this._editorialsRepository.Get().Select(x => new EditorialViewModel(x)).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
