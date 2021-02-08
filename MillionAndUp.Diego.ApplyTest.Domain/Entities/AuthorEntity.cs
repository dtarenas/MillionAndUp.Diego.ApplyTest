namespace MillionAndUp.Diego.ApplyTest.Domain.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Author Entity Class
    /// </summary>
    [Table(name: "authors")]
    public class AuthorEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorEntity"/> class.
        /// </summary>
        public AuthorEntity()
        {
            this.Books = new HashSet<BookEntity>();
        }

        /// <summary>
        /// Gets or sets the author identifier.
        /// </summary>
        /// <value>
        /// The author identifier.
        /// </value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        [Column(name: "author_id")]
        public int AuthorId { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [Display(Name = "First Name")]
        [Column(name: "first_name", TypeName = "VARCHAR(45)")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [MaxLength(45, ErrorMessage = "{0} must have {1} maximum characters.")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        /// <value>
        /// The surname.
        /// </value>
        [Display(Name = "Surname")]
        [Column(name: "surname", TypeName = "VARCHAR(45)")]
        [MaxLength(45, ErrorMessage = "{0} must have {1} maximum characters.")]
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the books.
        /// </summary>
        /// <value>
        /// The books.
        /// </value>
        public ICollection<BookEntity> Books { get; set; }

        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public string FullName => $"{this.FirstName} {this.Surname}";
    }
}
