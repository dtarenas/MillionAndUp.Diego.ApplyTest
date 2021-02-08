namespace MillionAndUp.Diego.ApplyTest.Domain.ViewModels
{
    using MillionAndUp.Diego.ApplyTest.Domain.Entities;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Book View Model
    /// </summary>
    public class BookViewModel
    {
        public BookViewModel(BookEntity bookEntity)
        {
            this.ISBN = bookEntity.ISBN;
            this.Title = bookEntity.Title;
            this.Synopsis = bookEntity.Synopsis;
            this.NumberOfPages = bookEntity.NumberOfPages;
            this.EditorialInfo = bookEntity.FkEditorial.NameWithHeadquarter;
            this.AuthorInfo = bookEntity.FkAuthor.FullName;
        }

        /// <summary>
        /// Gets the isbn.
        /// </summary>
        /// <value>
        /// The isbn.
        /// </value>
        [Display(Name = "ISBN")]
        public int ISBN { get; }

        /// <summary>
        /// Gets or sets the editorial information.
        /// </summary>
        /// <value>
        /// The editorial information.
        /// </value>
        [Display(Name = "Editorial")]
        public string EditorialInfo { get; set; }

        /// <summary>
        /// Gets or sets the author information.
        /// </summary>
        /// <value>
        /// The author information.
        /// </value>
        [Display(Name = "Author")]
        public string AuthorInfo { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [Display(Name = "Title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the synopsis.
        /// </summary>
        /// <value>
        /// The synopsis.
        /// </value>
        [Display(Name = "Synopsis")]
        public string Synopsis { get; set; }

        /// <summary>
        /// Gets or sets the number of pages.
        /// </summary>
        /// <value>
        /// The number of pages.
        /// </value>
        [Display(Name = "Number Of Pages")]
        public int NumberOfPages { get; set; }
    }
}
