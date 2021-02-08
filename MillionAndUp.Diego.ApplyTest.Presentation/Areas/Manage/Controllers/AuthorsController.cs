namespace MillionAndUp.Diego.ApplyTest.Presentation.Areas.Manage.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MillionAndUp.Diego.ApplyTest.Domain.Entities;
    using MillionAndUp.Diego.ApplyTest.Infrastructure.DAL.DbContexts;
    using MillionAndUp.Diego.ApplyTest.Infrastructure.DAL.Repo;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Authors Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Area("Manage")]
    public class AuthorsController : Controller
    {
        /// <summary>
        /// The authors repo
        /// </summary>
        private readonly IGenericRepository<AuthorEntity> _authorsRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorsController"/> class.
        /// </summary>
        /// <param name="authorsRepo">The authors repo.</param>
        public AuthorsController(IGenericRepository<AuthorEntity> authorsRepo)
        {
            this._authorsRepo = authorsRepo;
        }

        // GET: Manage/Authors
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>Index View</returns>
        public async Task<IActionResult> Index()
        {
            return View(await this._authorsRepo.Get().ToListAsync());
        }

        // GET: Manage/Authors/Details/5
        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Details View</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorEntity = await this._authorsRepo.Get()
                .FirstOrDefaultAsync(m => m.AuthorId == id);
            if (authorEntity == null)
            {
                return NotFound();
            }

            return View(authorEntity);
        }

        // GET: Manage/Authors/Create
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>Create View</returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Manage/Authors/Create
        /// <summary>
        /// Creates the specified author entity.
        /// </summary>
        /// <param name="authorEntity">The author entity.</param>
        /// <returns>Create Result</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AuthorEntity authorEntity)
        {
            if (ModelState.IsValid)
            {
                await this._authorsRepo.AddAsync(authorEntity);
                await this._authorsRepo.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(authorEntity);
        }

        // GET: Manage/Authors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorEntity = await this._authorsRepo.Get().FirstOrDefaultAsync(x => x.AuthorId == id);
            if (authorEntity == null)
            {
                return NotFound();
            }
            return View(authorEntity);
        }

        // POST: Manage/Authors/Edit/5
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="authorEntity">The author entity.</param>
        /// <returns>Edit View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AuthorEntity authorEntity)
        {
            if (id != authorEntity.AuthorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this._authorsRepo.Update(authorEntity);
                    await this._authorsRepo.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorEntityExists(authorEntity.AuthorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(authorEntity);
        }

        // GET: Manage/Authors/Delete/5
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Delete View</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorEntity = await this._authorsRepo.Get()
                .FirstOrDefaultAsync(m => m.AuthorId == id);
            if (authorEntity == null)
            {
                return NotFound();
            }

            return View(authorEntity);
        }

        // POST: Manage/Authors/Delete/5
        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Delete Result</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this._authorsRepo.RemoveAsync(id);
            await this._authorsRepo.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Authors the entity exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Bool control</returns>
        private bool AuthorEntityExists(int id)
        {
            return this._authorsRepo.Get().Any(e => e.AuthorId == id);
        }
    }
}
