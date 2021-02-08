namespace MillionAndUp.Diego.ApplyTest.UnitTest.Infrastructure.Services
{
    using MillionAndUp.Diego.ApplyTest.Domain.Entities;
    using MillionAndUp.Diego.ApplyTest.Domain.ViewModels;
    using MillionAndUp.Diego.ApplyTest.Infrastructure.Services;
    using Moq;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Service Test
    /// </summary>
    public class ServiceTest
    {
        /// <summary>
        /// The service bl
        /// </summary>
        private Mock<IServiceBL> serviceBL;

        /// <summary>
        /// The authors
        /// </summary>
        private IList<AuthorEntity> authors;

        /// <summary>
        /// The editorials
        /// </summary>
        private IList<EditorialEntity> editorials;

        /// <summary>
        /// The books
        /// </summary>
        private IList<BookEntity> books;

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.serviceBL = new Mock<IServiceBL>();
            this.CreateAuthors();
            this.CreateEditorials();
            this.CreateBooks();
        }

        /// <summary>
        /// Tests the get listing data.
        /// </summary
        [Test]
        public async Task TestGetListingData()
        {
            this.serviceBL.Setup(x => x.GetAuthorListing()).Returns(Task.FromResult(this.authors.Select(x => new AuthorViewModel(x)).ToList()));
            this.serviceBL.Setup(x => x.GetEditorialListing()).Returns(Task.FromResult(this.editorials.Select(x => new EditorialViewModel(x)).ToList()));
            this.serviceBL.Setup(x => x.GetBookListing()).Returns(Task.FromResult(this.books.Select(x => new BookViewModel(x)).ToList()));
            Assert.IsTrue((await this.serviceBL.Object.GetAuthorListing()).Count > 0);
            Assert.IsTrue((await this.serviceBL.Object.GetEditorialListing()).Count > 0);
            Assert.IsTrue((await this.serviceBL.Object.GetBookListing()).Count > 0);
        }


        /// <summary>
        /// Creates the authors.
        /// </summary>
        private void CreateAuthors()
        {
            this.authors = new List<AuthorEntity>
            {
                new AuthorEntity() { AuthorId = 1, FirstName = "TestName1", Surname = "TestSurname1" },
                new AuthorEntity() { AuthorId = 2, FirstName = "TestName2", Surname = "TestSurname2" },
                new AuthorEntity() { AuthorId = 3, FirstName = "TestName3", Surname = "TestSurname3" },
                new AuthorEntity() { AuthorId = 4, FirstName = "TestName4", Surname = "TestSurname4" }
            };
        }

        /// <summary>
        /// Creates the editorial.
        /// </summary>
        private void CreateEditorials()
        {
            this.editorials = new List<EditorialEntity>
            {
                new EditorialEntity() { EditorialId = 1, Name = "Editorial1", Headquarter = "Headquarter1" },
                new EditorialEntity() { EditorialId = 2, Name = "Editorial2", Headquarter = "Headquarter2" },
                new EditorialEntity() { EditorialId = 3, Name = "Editorial3", Headquarter = "Headquarter3" },
                new EditorialEntity() { EditorialId = 4, Name = "Editorial4", Headquarter = "Headquarter4" }
            };
        }

        /// <summary>
        /// Creates the books.
        /// </summary>
        private void CreateBooks()
        {
            this.books = new List<BookEntity>
            {
                new BookEntity() { FkAuthorId = 1, FkEditorialId = 1, ISBN = 1, NumberOfPages = 300, Synopsis = "Synopsis Test 1", Title = "TestBook1", FkEditorial = this.editorials.First(x => x.EditorialId == 1), FkAuthor = this.authors.First(x => x.AuthorId == 1) },
                new BookEntity() { FkAuthorId = 2, FkEditorialId = 2, ISBN = 2, NumberOfPages = 301, Synopsis = "Synopsis Test 2", Title = "TestBook2", FkEditorial = this.editorials.First(x => x.EditorialId == 2), FkAuthor = this.authors.First(x => x.AuthorId == 2) },
                new BookEntity() { FkAuthorId = 3, FkEditorialId = 3, ISBN = 3, NumberOfPages = 302, Synopsis = "Synopsis Test 3", Title = "TestBook3", FkEditorial = this.editorials.First(x => x.EditorialId == 3), FkAuthor = this.authors.First(x => x.AuthorId == 3) },
                new BookEntity() { FkAuthorId = 4, FkEditorialId = 4, ISBN = 4, NumberOfPages = 303, Synopsis = "Synopsis Test 4", Title = "TestBook4", FkEditorial = this.editorials.First(x => x.EditorialId == 4), FkAuthor = this.authors.First(x => x.AuthorId == 4) }
            };
        }

    }
}
