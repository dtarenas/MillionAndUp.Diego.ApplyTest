namespace MillionAndUp.Diego.ApplyTest.Presentation.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MillionAndUp.Diego.ApplyTest.Infrastructure.Services;
    using System.Threading.Tasks;

    /// <summary>
    /// Books Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class BooksController : Controller
    {
        /// <summary>
        /// The books repository
        /// </summary>
        private readonly IServiceBL _serviceBL;

        /// <summary>
        /// Initializes a new instance of the <see cref="BooksController" /> class.
        /// </summary>
        /// <param name="serviceBL">The books repository.</param>
        public BooksController(IServiceBL serviceBL)
        {
            this._serviceBL = serviceBL;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>Index View</returns>
        public async Task<IActionResult> Index()
        {
            var books = await this._serviceBL.GetBookListing();
            return View(books);
        }
    }
}
