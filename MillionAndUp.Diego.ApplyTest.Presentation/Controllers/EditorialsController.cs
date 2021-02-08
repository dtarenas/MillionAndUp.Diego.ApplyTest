namespace MillionAndUp.Diego.ApplyTest.Presentation.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MillionAndUp.Diego.ApplyTest.Infrastructure.Services;
    using System.Threading.Tasks;

    /// <summary>
    /// Editorials Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class EditorialsController : Controller
    {
        /// <summary>
        /// The editorial repository
        /// </summary>
        private readonly IServiceBL _serviceBL;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorialsController" /> class.
        /// </summary>
        /// <param name="serviceBL">The books repository.</param>
        public EditorialsController(IServiceBL serviceBL)
        {
            this._serviceBL = serviceBL;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>Index View</returns>
        public async Task<IActionResult> Index()
        {
            var editorials = await this._serviceBL.GetEditorialListing();
            return View(editorials);
        }
    }
}
