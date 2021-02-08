namespace MillionAndUp.Diego.ApplyTest.Domain.ViewModels
{
    using MillionAndUp.Diego.ApplyTest.Domain.Entities;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Editorial View Model
    /// </summary>
    public class EditorialViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditorialViewModel"/> class.
        /// </summary>
        /// <param name="editorialEntity">The editorial entity.</param>
        public EditorialViewModel(EditorialEntity editorialEntity)
        {
            this.Name = editorialEntity.Name;
            this.Headquarter = editorialEntity.Headquarter;
            this.NameWithHeadquarter = editorialEntity.NameWithHeadquarter;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Display(Name = "Name")]
        public string Name { get; }

        /// <summary>
        /// Gets the headquarter.
        /// </summary>
        /// <value>
        /// The headquarter.
        /// </value>
        [Display(Name = "Headquarter")]
        public string Headquarter { get; }

        /// <summary>
        /// Gets the name with headquarter.
        /// </summary>
        /// <value>
        /// The name with headquarter.
        /// </value>
        public string NameWithHeadquarter { get; }
    }
}