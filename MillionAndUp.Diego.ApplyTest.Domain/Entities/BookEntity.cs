
namespace MillionAndUp.Diego.ApplyTest.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Books entity class
    /// </summary>
    [Table(name: "books")]
    public class BookEntity
    {
        /// <summary>
        /// Gets or sets the isbn.
        /// </summary>
        /// <value>
        /// The isbn.
        /// </value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ISBN")]
        [Column(name: "isbn")]
        public int ISBN { get; set; }

        /// <summary>
        /// Gets or sets the fk editorial identifier.
        /// </summary>
        /// <value>
        /// The fk editorial identifier.
        /// </value>
        [Display(Name = "Editorial")]
        [Column(name: "fk_editorial_id")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [ForeignKey("EditorialId")]
        public int FkEditorialId { get; set; }

        /// <summary>
        /// Gets or sets the fk author identifier.
        /// </summary>
        /// <value>
        /// The fk author identifier.
        /// </value>
        [Display(Name = "Author")]
        [Column(name: "fk_author_id")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [ForeignKey("AuthorId")]
        public int FkAuthorId { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [Display(Name = "Title")]
        [Column(name: "title", TypeName = "VARCHAR(45)")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [MaxLength(45, ErrorMessage = "{0} must have {1} maximum characters.")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the synopsis.
        /// </summary>
        /// <value>
        /// The synopsis.
        /// </value>
        [Display(Name = "Synopsis")]
        [Column(name: "synopsis", TypeName = "TEXT")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        public string Synopsis { get; set; }

        /// <summary>
        /// Gets or sets the number of pages.
        /// </summary>
        /// <value>
        /// The number of pages.
        /// </value>
        [Display(Name = "Number Of Pages")]
        [Column(name: "number_of_pages")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} must be mayor than {1}")]
        public int NumberOfPages { get; set; }

        /// <summary>
        /// Gets or sets the fk editorial.
        /// </summary>
        /// <value>
        /// The fk editorial.
        /// </value>
        public virtual EditorialEntity FkEditorial { get; set; }

        /// <summary>
        /// Gets or sets the fk author.
        /// </summary>
        /// <value>
        /// The fk author.
        /// </value>
        public virtual AuthorEntity FkAuthor { get; set; }
    }
}
