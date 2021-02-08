namespace MillionAndUp.Diego.ApplyTest.Domain.ViewModels
{
    using MillionAndUp.Diego.ApplyTest.Domain.Entities;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Author View Model
    /// </summary>
    public class AuthorViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorViewModel"/> class.
        /// </summary>
        /// <param name="authorEntity">The author entity.</param>
        public AuthorViewModel(AuthorEntity authorEntity)
        {
            this.FirstName = authorEntity.FirstName;
            this.Surname = authorEntity.Surname;
            this.FullName = authorEntity.FullName;
        }

        /// <summary>
        /// Gets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [Display(Name = "First Name")]
        public string FirstName { get; }

        /// <summary>
        /// Gets the surname.
        /// </summary>
        /// <value>
        /// The surname.
        /// </value>
        [Display(Name = "Surname")]
        public string Surname { get; }

        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        [Display(Name = "Full name")]
        public string FullName { get; }
    }
}
