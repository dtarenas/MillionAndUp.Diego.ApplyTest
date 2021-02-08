namespace MillionAndUp.Diego.ApplyTest.Domain.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Editorial Entity class
    /// </summary>
    [Table(name: "editorials")]
    public class EditorialEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditorialEntity" /> class.
        /// </summary>
        public EditorialEntity()
        {
            this.Books = new HashSet<BookEntity>();
        }

        /// <summary>
        /// Gets or sets the editorial identifier.
        /// </summary>
        /// <value>
        /// The editorial identifier.
        /// </value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        [Column(name: "editorial_id")]
        public int EditorialId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Display(Name = "Name")]
        [Column(name: "name", TypeName = "VARCHAR(45)")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [MaxLength(45, ErrorMessage = "{0} must have {1} maximum characters.")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the headquarter.
        /// </summary>
        /// <value>
        /// The headquarter.
        /// </value>
        [Display(Name = "Headquarter")]
        [Column(name: "headquarter", TypeName = "VARCHAR(45)")]
        [Required(ErrorMessage = "{0} is mandatory.")]
        [MaxLength(45, ErrorMessage = "{0} must have {1} maximum characters.")]
        public string Headquarter { get; set; }

        /// <summary>
        /// Gets or sets the books.
        /// </summary>
        /// <value>
        /// The books.
        /// </value>
        public virtual ICollection<BookEntity> Books { get; set; }

        /// <summary>
        /// Gets the name with headquarter.
        /// </summary>
        /// <value>
        /// The name with headquarter.
        /// </value>
        public string NameWithHeadquarter => $"{this.Name} - {this.Headquarter}";
    }
}
