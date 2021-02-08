namespace MillionAndUp.Diego.ApplyTest.UnitTest.Infrastructure.DAL
{
    using MillionAndUp.Diego.ApplyTest.Domain.Entities;
    using MillionAndUp.Diego.ApplyTest.Infrastructure.DAL.Repo;
    using Moq;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Repository Test
    /// </summary>
    public class RepoTest
    {
        /// <summary>
        /// The author repo
        /// </summary>
        private Mock<IGenericRepository<AuthorEntity>> authorRepo;

        /// <summary>
        /// The editorial repo
        /// </summary>
        private Mock<IGenericRepository<EditorialEntity>> editorialRepo;

        /// <summary>
        /// The book repo
        /// </summary>
        private Mock<IGenericRepository<BookEntity>> bookRepo;

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
            this.authorRepo = new Mock<IGenericRepository<AuthorEntity>>();
            this.editorialRepo = new Mock<IGenericRepository<EditorialEntity>>();
            this.bookRepo = new Mock<IGenericRepository<BookEntity>>();
            this.CreateAuthors();
            this.CreateEditorials();
            this.CreateBooks();
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        [Test]
        public void GetData()
        {
            var authorRepoMoq = this.authorRepo.Setup(x => x.Get()).Returns(this.authors.AsQueryable());
            var editorialRepoMoq = this.editorialRepo.Setup(x => x.Get()).Returns(this.editorials.AsQueryable());
            var bookRepoMoq = this.bookRepo.Setup(x => x.Get()).Returns(this.books.AsQueryable());

            Assert.IsNotNull(authorRepoMoq);
            Assert.IsNotNull(editorialRepoMoq);
            Assert.IsNotNull(bookRepoMoq);
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
                new BookEntity() { FkAuthorId = 1, FkEditorialId = 1, ISBN = 1, NumberOfPages = 300, Synopsis = "Synopsis Test 1", Title = "TestBook1" },
                new BookEntity() { FkAuthorId = 2, FkEditorialId = 2, ISBN = 2, NumberOfPages = 301, Synopsis = "Synopsis Test 2", Title = "TestBook2" },
                new BookEntity() { FkAuthorId = 3, FkEditorialId = 3, ISBN = 3, NumberOfPages = 302, Synopsis = "Synopsis Test 3", Title = "TestBook3" },
                new BookEntity() { FkAuthorId = 4, FkEditorialId = 4, ISBN = 4, NumberOfPages = 303, Synopsis = "Synopsis Test 4", Title = "TestBook4" }
            };
        }

    }
}
