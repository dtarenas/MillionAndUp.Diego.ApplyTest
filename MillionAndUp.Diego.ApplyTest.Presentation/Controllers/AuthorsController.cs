namespace MillionAndUp.Diego.ApplyTest.Presentation.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MillionAndUp.Diego.ApplyTest.Infrastructure.Services;
    using System.Threading.Tasks;

    /// <summary>
    /// Authors Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class AuthorsController : Controller
    {
        /// <summary>
        /// The editorial repository
        /// </summary>
        private readonly IServiceBL _serviceBL;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorsController"/> class.
        /// </summary>
        /// <param name="authorRepository">The author repository.</param>
        public AuthorsController(IServiceBL serviceBL)
        {
            this._serviceBL = serviceBL;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>Index View</returns>
        public async Task<IActionResult> Index()
        {
            var authors = await this._serviceBL.GetAuthorListing();
            return View(authors);
        }
    }
}
